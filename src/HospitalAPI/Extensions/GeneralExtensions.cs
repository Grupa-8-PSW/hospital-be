namespace HospitalAPI.Extensions;

public static class GeneralExtensions
{
    public static int GetUserId(this HttpContext httpContext)
    {
        var successful = Int32.TryParse(
            httpContext.User.Claims.Single(c => c.Type == "Id").Value, out var id);

        if (!successful) throw new Exception("Invalid id");

        return id;
    }
}