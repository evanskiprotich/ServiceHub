using api.Dtos.ChatMessage;
using api.Dtos.Payment;
using api.Dtos.Review;
using api.Dtos.Service;
using api.Dtos.ServiceRequest;
using api.Dtos.User;
using api.Models;
using AutoMapper;

namespace api.Data
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            // User
            CreateMap<User, UserDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();

            // Service
            CreateMap<Service, ServiceDto>();
            CreateMap<ServiceCreateDto, Service>();
            CreateMap<ServiceUpdateDto, Service>();

            // ServiceRequest
            CreateMap<ServiceRequest, ServiceRequestDto>();
            CreateMap<ServiceRequestCreateDto, ServiceRequest>();
            CreateMap<ServiceRequestUpdateDto, ServiceRequest>();

            // Payment
            CreateMap<Payment, PaymentDto>();
            CreateMap<PaymentCreateDto, Payment>();

            // Review
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewCreateDto, Review>();

            // ChatMessage
            CreateMap<ChatMessage, ChatMessageDto>();
            CreateMap<ChatMessageCreateDto, ChatMessage>();
        }
    }
}
