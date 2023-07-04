namespace TestMailer.Api;

public static class ApplicationPipeline
{
    /// <summary>
    /// Конфигурация пайплайна (миддлваров) приложения
    /// </summary>
    /// <param name="app">Экземпляр приложения</param>
    /// <returns></returns>
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        
        return app;
    }
}