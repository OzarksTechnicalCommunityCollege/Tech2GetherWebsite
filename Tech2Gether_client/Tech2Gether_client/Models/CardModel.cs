// Models/CardModel.cs

namespace Tech2Gether.Models
{
    public class CardModel
    {
        public string? Id              { get; set; }

        // Icon
        public string? IconSvg         { get; set; }  // inner SVG path(s) as raw HTML
        public string  IconViewBox     { get; set; } = "0 0 512 512";
        public string  IconColor       { get; set; } = "text-binary-blue";

        // Text content
        public string? Title           { get; set; }
        public string? Subtitle        { get; set; }
        public string  SubtitleBg      { get; set; } = "bg-binary-blue";
        public string  SubtitleText    { get; set; } = "text-white";
        public string? Description     { get; set; }
        public string? AdditionalInfo  { get; set; }  // supports inline HTML (e.g. <strong>)
        public string  AdditionalInfoBg { get; set; } = "bg-gray-100";

        // Layout
        public string  BorderColor     { get; set; } = "border-t-binary-blue";
        public string  ClassName       { get; set; } = "";
        public string  Size            { get; set; } = "lg";   // "sm" | "md" | "lg"
        public bool    Centered        { get; set; } = true;

        // Details list
        public List<CardDetail> Details { get; set; } = new();

        // Button
        public CardButton? Button      { get; set; }
    }

    public class CardDetail
    {
        public string? IconSvg     { get; set; }  // inner SVG path(s)
        public string  IconViewBox { get; set; } = "0 0 512 512";
        public string? Color       { get; set; }  // overrides card IconColor if set
        public string  Text        { get; set; } = "";
    }

    public class CardButton
    {
        public string  Text        { get; set; } = "";
        public string? Href        { get; set; }  // null = renders a <button>, set = renders an <a>
        public string? IconSvg     { get; set; }
        public string  IconViewBox { get; set; } = "0 0 512 512";
        public string? ClassName   { get; set; }
        public bool    External    { get; set; } = false;
    }
}
