using MedicalServicesAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalServicesAPI;

internal static class Program
{
	public static readonly DiplomContext ctx = new();

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
		ctx.AdBlocks.Load();

		ctx.Analyses.Load();
		ctx.AnalysisCategories.Load();
		ctx.AnalysisOrders.Load();

		ctx.EmailLists.Load();
		ctx.LoginLists.Load();
		ctx.PassportLists.Load();
		ctx.PhoneLists.Load();

		ctx.Messages.Load();
		ctx.MessagesMessages.Load();

		ctx.Patients.Load();
		ctx.PatientAnalysisAddresses.Load();
		ctx.PatientAnalysisCarts.Load();
		ctx.PatientAnalysisCartItems.Load();
		ctx.PatientsDataLists.Load();

		ctx.Users.Load();
	}
}