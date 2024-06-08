using Application.IServices;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public class ElderInformationService : IElderInformationService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ElderInformationService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
	}
}
