using api.Dtos.ChatMessage;
using api.Dtos.Dispute;
using api.Dtos.Notification;
using api.Dtos.Payment;
using api.Dtos.Review;
using api.Dtos.Service;
using api.Dtos.ServiceRequest;
using api.Dtos.User;
using api.Dtos.Withdrawal;
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

            // ChatMessage
            CreateMap<ChatMessage, ChatMessageDto>();
            CreateMap<ChatMessageCreateDto, ChatMessage>();
            CreateMap<ChatMessageUpdateDto, ChatMessage>();

            // Dispute
            CreateMap<Dispute, DisputeDto>();
            CreateMap<DisputeCreateDto, Dispute>();
            CreateMap<DisputeUpdateDto, Dispute>();

            // Notification
            CreateMap<Notification, NotificationDto>();
            CreateMap<NotificationCreateDto, Notification>();
            CreateMap<NotificationUpdateDto, Notification>();

            // Payment
            CreateMap<Payment, PaymentDto>();
            CreateMap<PaymentCreateDto, Payment>();
            CreateMap<PaymentUpdateDto, Payment>();

            // Review
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewCreateDto, Review>();
            CreateMap<ReviewUpdateDto, Review>();

            // Service
            CreateMap<Service, ServiceDto>();
            CreateMap<ServiceCreateDto, Service>();
            CreateMap<ServiceUpdateDto, Service>();

            // ServiceRequest
            CreateMap<ServiceRequest, ServiceRequestDto>();
            CreateMap<ServiceRequestCreateDto, ServiceRequest>();
            CreateMap<ServiceRequestUpdateDto, ServiceRequest>();

            // Withdrawal
            CreateMap<Withdrawal, WithdrawalDto>();
            CreateMap<WithdrawalCreateDto, Withdrawal>();
            CreateMap<WithdrawalUpdateDto, Withdrawal>();
        }
    }
}
