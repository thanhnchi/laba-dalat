using AutoMapper;
using LABA_WebAdmin_Corporate.Lib;
using LABA_WebAdmin_Corporate.Models;
using LABA_WebAdmin_Corporate.ViewModels;
using System.Linq;

namespace LABA_WebAdmin_Corporate.Mapper
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			#region Farm
			CreateMap<M_Farm, EM_Farm>()
			  .ForMember(destination => destination.imageFavicon,
			  options => options.MapFrom(source => source.imageFavicon));
			CreateMap<M_Address, EM_Address>();
			CreateMap<M_About, EM_About>();
			CreateMap<M_NewsCategory, EM_NewsCategory>();
			CreateMap<M_News, EM_News>();
			#endregion

			#region SelectDropdown
			CreateMap<M_Province, VM_SelectDropDown>();
			CreateMap<M_District, VM_SelectDropDown>();
			CreateMap<M_Ward, VM_SelectDropDown>();
			#endregion
		}
	}
}
