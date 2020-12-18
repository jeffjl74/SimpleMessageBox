using System.Drawing;
using System.Text;

namespace SimpleMessageBoxes
{
    /// <summary>
    /// Defines the text alignment for a text group.
    /// </summary>
    public class RtfAlign
    {
        /// <summary>
        /// Sets left aligned text.
        /// </summary>
        public const int Left = 1;
        /// <summary>
        /// Sets right aligned text.
        /// </summary>
        public const int Right = 2;
        /// <summary>
        /// Sets center aligned text.
        /// </summary>
        public const int Center = 3;
        /// <summary>
        /// Sets justified text.
        /// </summary>
        public const int Justify = 4;

    }

    /// <summary>
    /// Defines the rtf control word(s) for a text group.
    /// </summary>
    public class RtfControl
    {
        /// <summary>
        /// Font style bits set with <see cref="RtfStyle"/>
        /// </summary>
        public int? style;
        /// <summary>
        /// Font <see cref="Color"/>
        /// </summary>
        public Color? color;
        /// <summary>
        /// Text group alignment set with <see cref="RtfAlign"/>
        /// </summary>
        public int? alignment;
        /// <summary>
        /// Font name.
        /// </summary>
        public string font;
        /// <summary>
        /// Font size in half points. e.g.24 halfPts is a 12 point font.
        /// </summary>
        public int? halfPts;

        /// <summary>
        /// Sets empty rtf contol words for a text group.
        /// </summary>
        public RtfControl()
        {
            // to provide and easy, "empty" class
        }
    }

    /// <summary>
    /// Defines the font style for a text group. Styles may be combined via bitwise 'or'.
    /// </summary>
    public class RtfStyle
    {
        /// <summary>
        /// Set for normal text.
        /// </summary>
        public const int Plain = 1;
        /// <summary>
        /// Set for bold text. May be combined with other styles.
        /// </summary>
        public const int Bold = Plain << 1;
        /// <summary>
        /// Set for italic text. May be combined with other styles.
        /// </summary>
        public const int Italic = Bold << 1;
        /// <summary>
        /// set for underlined text. May be combined with other styles.
        /// </summary>
        public const int Underline = Italic << 1;
        /// <summary>
        /// set for strike through text. May be combined with other styles.
        /// </summary>
        public const int Strikethrough = Underline << 1;
        /// <summary>
        /// set for all caps text. May be combined with other styles.
        /// </summary>
        public const int Caps = Strikethrough << 1;
    }

    /// <summary>
    /// A very minimalistic way to construct a simple RTF string. It can do color, alignment, 
    /// font name (not verified in any way), font size, 
    /// bold, italic, caps, strikethrough and underline.
    /// </summary>
    public class RtfBuilder
    {
        /// <summary>
        /// Builds the rtf string
        /// </summary>
        StringBuilder rtf;
        /// <summary>
        /// Color table entry number. Starts with 1.
        /// </summary>
        int colorEntries = 0;
        /// <summary>
        /// Font table entry number. The RichTextBox already defines font 0.
        /// </summary>
        int fontEntries = 1;
        /// <summary>
        /// If there is an alignement control, need to remember that so it can be closed.
        /// </summary>
        bool haveAlignment = false;
        /// <summary>
        /// Collects the color table entries.
        /// </summary>
        StringBuilder colorTable = new StringBuilder();
        /// <summary>
        /// Collects the font table entries.
        /// </summary>
        StringBuilder fontTable = new StringBuilder();

        /// <summary>
        /// Initialize an empty rtf builder.
        /// </summary>
        public RtfBuilder()
        {
            rtf = new StringBuilder();
        }

        /// <summary>
        /// Append the specified text group to the builder, adding a \par to end the line.
        /// </summary>
        /// <param name="style"><see cref="RtfControl"/></param>
        /// <param name="text">Text to add to the text group.</param>
        public void AppendLine(RtfControl style, string text)
        {
            BuildString(style, text, true);
        }

        /// <summary>
        /// Append the specified text to the builder without closing the group.
        /// </summary>
        /// <param name="style"><see cref="RtfControl"/></param>
        /// <param name="text">Text to add to the text group.</param>
        public void Append(RtfControl style, string text)
        {
            BuildString(style, text, false);
        }

        /// <summary>
        /// Append the text to the rtf builder as plain text without closing the group.
        /// </summary>
        /// <param name="text">Text to add to the text group.</param>
        public void Append(string text)
        {
            BuildString(new RtfControl(), text, false);
        }

        /// <summary>
        /// Append the text to the rtf builder as plain text, adding a \par to end the line.
        /// </summary>
        /// <param name="text">Text to add to the text group.</param>
        public void AppendLine(string text)
        {
            BuildString(new RtfControl(), text, true);
        }

        /// <summary>
        /// Generates an rtf "document" from the previously appended data.
        /// </summary>
        /// <returns>rtf document as a string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{"); //document open

            //put the color table & font table in the header
            if (colorTable.Length > 0)
            {
                //close the color table, then put it at the front
                colorTable.Append("}");
                sb.Append(colorTable.ToString());
            }

            if (fontTable.Length > 0)
            {
                //close the font table, then add it
                fontTable.Append("}");
                sb.Append(fontTable.ToString());
            }

            //add the body
            sb.Append(rtf.ToString());

            sb.Append("}"); //document close

            return sb.ToString();
        }

        /// <summary>
        /// Converts the incoming control and text into an rtf group added to the builder.
        /// </summary>
        /// <param name="style"><see cref="RtfControl"/> control word(s) for the text group.</param>
        /// <param name="text">Plain text for the text group.</param>
        /// <param name="endParagraph">True to close the text group. False to leave it open.</param>
        void BuildString(RtfControl style, string text, bool endParagraph)
        {
            // we only have one color table, collect entries for inclusion during .ToString()
            if (style.color.HasValue)
            {
                if (colorTable.Length == 0)
                    colorTable.Append(@"{\colortbl;");
                colorTable.Append($@"\red{style.color.Value.R}\green{style.color.Value.G}\blue{style.color.Value.B};");
                colorEntries++;
            }

            // we only have one font table, collect entries for inclusion during .ToString()
            if (!string.IsNullOrEmpty(style.font))
            {
                if (fontTable.Length == 0)
                    fontTable.Append(@"{\fonttbl");
                fontTable.Append($@"{{\f{fontEntries}\fcharset0 {style.font};}}");
                fontEntries++;
            }

            // alignment needs to go first, since we need another set of braces
            // to enclose it
            if (style.alignment.HasValue)
            {
                string aligncode = "";
                // if it has a justification, we need another group level of {}
                switch (style.alignment)
                {
                    case RtfAlign.Center:
                        aligncode = @"{\qc";
                        break;
                    case RtfAlign.Left:
                        aligncode = @"{\ql";
                        break;
                    case RtfAlign.Right:
                        aligncode = @"{\qr";
                        break;
                    case RtfAlign.Justify:
                        aligncode = @"{\qj";
                        break;
                }
                if (!string.IsNullOrEmpty(aligncode))
                {
                    rtf.Append($@"{aligncode}");
                    haveAlignment = true;
                }
            }

            // start the text group
            rtf.Append(@"{");

            // set the color
            if (style.color.HasValue)
                rtf.Append($@"\cf{colorEntries}");

            // style the font
            if (style.style.HasValue)
            {
                int value = style.style.Value;

                if ((value & RtfStyle.Bold) > 0)
                    rtf.Append($@"\b");

                if ((value & RtfStyle.Italic) > 0)
                    rtf.Append($@"\i");

                if ((value & RtfStyle.Underline) > 0)
                    rtf.Append($@"\ul");

                if ((value & RtfStyle.Strikethrough) > 0)
                    rtf.Append($@"\strike");

                if ((value & RtfStyle.Caps) > 0)
                    rtf.Append($@"\caps");
            }

            // set the font
            if (!string.IsNullOrEmpty(style.font))
                rtf.Append($@"\f{fontEntries-1}");

            // set the font size
            if (style.halfPts.HasValue)
                rtf.Append($@"\fs{style.halfPts}");

            // add the text, close the group(s)
            if (endParagraph && haveAlignment)
            {
                //close the text group, then the alignment group
                // with a paragraph reset-to-default
                rtf.Append($@" {text}\par}}\pard}}");
                haveAlignment = false;
            }
            else if (endParagraph && !haveAlignment)
            {
                //end the paragraph, then close the text group
                rtf.Append($@" {text}\par}}");
            }
            else
            {
                //close the text group
                rtf.Append($@" {text}}}");
            }
        }
    }
}
