namespace CognizantCaseStudy.Models
{
    public record CodeSubmitModel(string args,
                                  string clientId, 
                                  string clientSecret,
                                  string script,
                                  string language,
                                  string versionIndex);
}
