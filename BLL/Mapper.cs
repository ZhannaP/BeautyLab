using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using BLL.Requests;
using BLL.Responses;
using BLL.Services;

using DAL.Entities;

namespace BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Appointment, AppointmentResponse>()
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client.User.FirstName + " " + src.Client.User.LastName))
                .ForMember(dest => dest.MasterName, opt => opt.MapFrom(src => src.Master.User.FirstName + " " + src.Master.User.LastName))
                .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Service.Name));

            CreateMap<AppointmentRequest, Appointment>();

            CreateMap<Client, ClientResponse>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));

            CreateMap<ClientRequest, Client>();

            CreateMap<Master, MasterResponse>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));


            CreateMap<MasterRequest, Master>();

            CreateMap<DAL.Entities.MasterService, MasterServiceResponse>()
                .ForMember(dest => dest.MasterName, opt => opt.MapFrom(src => src.Master.User.FirstName + " " + src.Master.User.LastName))
                .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Service.Name));

            CreateMap<MasterServiceRequest, DAL.Entities.MasterService>();

            CreateMap<Payment, PaymentResponse>()
                .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Appointment.Service.Name))
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Appointment.Client.User.FirstName + " " + src.Appointment.Client.User.LastName));

            CreateMap<PaymentRequest, Payment>();

            CreateMap<Service, ServiceResponse>();
            CreateMap<ServiceRequest, Service>();

            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));

            CreateMap<UserRequest, User>();

            CreateMap<Role, RoleResponse>();
            CreateMap<RoleRequest, Role>();
        }
    }
}
