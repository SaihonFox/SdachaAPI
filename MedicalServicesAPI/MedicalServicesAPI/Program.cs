using MedicalServicesAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalServicesAPI;

public class Program
{
	public static diplomContext ctx = new();

	public static void Main(string[] args)
	{
		CtxLoad();

		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.

		builder.Services.AddControllers();
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app
			.UseHttpsRedirection()
			.UseAuthorization();


		app.MapControllers();

		app.Run();
	}

	static void CtxLoad()
	{
		ctx.ad_blocks.Load();

		ctx.analyses.Load();
		ctx.analysis_categories.Load();
		ctx.analysis_orders.Load();

		ctx.messages.Load();
		ctx.messages_messages.Load();

		ctx.patients.Load();
		ctx.patient_analysis_addresses.Load();
		ctx.patient_analysis_carts.Load();
		ctx.patient_analysis_cart_items.Load();

		ctx.users.Load();
	}
}