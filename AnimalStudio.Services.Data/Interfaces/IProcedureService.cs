﻿using AnimalStudio.Web.ViewModels;
using AnimalStudio.Web.ViewModels.Procedure;

namespace AnimalStudio.Services.Data.Interfaces
{
	public interface IProcedureService
	{
		Task<IEnumerable<ProcedureIndexViewModel>> IndexGetAllProceduresAsync();
				
		Task AddProcedureAsync(AddProcedureFormModel model);

		Task ProcedureDelete(int id);

		Task<ProcedureDetailsViewModel> GetProcedureDetailsByIdAsync(int id);

    }
}
