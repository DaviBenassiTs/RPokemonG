namespace RPokemonG.Builders
{
    public static class CorsBuilder
    {
        public static void UseCorsApp(this WebApplication app)
        {
            app.UseCors(
            builder =>
            {
                builder.SetIsOriginAllowed(origin => true);
                builder.AllowCredentials();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
    });
        }
    }
}
