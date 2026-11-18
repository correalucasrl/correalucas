namespace Portfolio.Content;

public enum Lang { Es, En }

public enum Diagram { SummaryTables, StockFlow, PersonnelModel, ClaimsMap }

public sealed record NavText(string About, string Work, string Skills, string Education, string Contact, string Cv, string SwitchLang, string SwitchLangHref);

public sealed record HeroText(string Greeting, string Role, string Pitch, string Location, string CtaWork, string CtaCv, string Available);

public sealed record Highlight(string Value, string Label);

public sealed record AboutText(string Title, IReadOnlyList<string> Paragraphs, IReadOnlyList<Highlight> Highlights);

public sealed record CaseStudy(
    string Id,
    string Tag,
    string Title,
    string Summary,
    string Problem,
    string Solution,
    string Result,
    IReadOnlyList<string> Stack,
    Diagram Diagram,
    string DiagramCaption);

public sealed record WorkText(string Title, string Intro, string ProblemLabel, string SolutionLabel, string ResultLabel, string Note, IReadOnlyList<CaseStudy> Cases);

public sealed record SkillGroup(string Name, IReadOnlyList<string> Items);

public sealed record SkillsText(string Title, IReadOnlyList<SkillGroup> Groups);

public sealed record EducationItem(string Title, string Place, string When, bool InProgress, string? Url = null);

public sealed record EducationText(string Title, string InProgressLabel, IReadOnlyList<EducationItem> Items);

public sealed record ExperienceText(string Title, string Company, string Client, string Period, string Mode, IReadOnlyList<string> Stages);

public sealed record ContactText(string Title, string Pitch, string EmailLabel, string LinkedInLabel, string CvLabel);

public sealed record SiteContent(
    Lang Lang,
    string HtmlLang,
    string PageTitle,
    string MetaDescription,
    string CvFile,
    NavText Nav,
    HeroText Hero,
    AboutText About,
    ExperienceText Experience,
    WorkText Work,
    SkillsText Skills,
    EducationText Education,
    ContactText Contact,
    string Footer);

public static class Profile
{
    public const string Name = "Lucas Correa";
    public const string Email = "correalucasrl@gmail.com";
    public const string LinkedIn = "https://www.linkedin.com/in/correalucasrl";
    public const string Site = "https://correalucas.com";
}
