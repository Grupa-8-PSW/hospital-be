namespace HospitalAPI.Extensions;

public static class GeneralExtensions
{
    public static int GetUserId(this HttpContext httpContext)
    {
        var successful = int.TryParse(
            httpContext.User.Claims.Single(c => c.Type == "Id").Value, out var id);

        if (!successful) throw new Exception("Invalid id");

        return id;
    }
}