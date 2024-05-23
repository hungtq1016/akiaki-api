namespace AkiAki
{
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {
            CreateMap<RoleRequest, Role>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Role, RoleResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<RoleRequest>>, PaginationResponse<List<Role>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<Role>>, PaginationResponse<List<RoleResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<PermissionRequest, Permission>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Permission, PermissionResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<PermissionRequest>>, PaginationResponse<List<Permission>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<Permission>>, PaginationResponse<List<PermissionResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UserRequest, User>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<User, UserResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<UserRequest>>, PaginationResponse<List<User>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<User>>, PaginationResponse<List<UserResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<GroupRequest, Group>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Group, GroupResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<GroupRequest>>, PaginationResponse<List<Group>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<Group>>, PaginationResponse<List<GroupResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<AssignmentRequest, Assignment>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Assignment, AssignmentResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<AssignmentRequest>>, PaginationResponse<List<Assignment>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<Assignment>>, PaginationResponse<List<AssignmentResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ImageRequest, Image>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Image, Image>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Image, ImageResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<AbstractFile, Image>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<LocaleRequest, Locale>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Locale, LocaleResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<LocaleRequest>>, PaginationResponse<List<Locale>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<Locale>>, PaginationResponse<List<LocaleResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<PrescriptionRequest, LocaleKey>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<LocaleKey, LocaleKeyResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<PrescriptionRequest>>, PaginationResponse<List<LocaleKey>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<LocaleKey>>, PaginationResponse<List<LocaleKeyResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<LanguageRequest, Language>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Language, LanguageResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<LanguageRequest>>, PaginationResponse<List<Language>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<Language>>, PaginationResponse<List<LanguageResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ScheduleRequest, Schedule>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Schedule, ScheduleResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<ScheduleRequest>>, PaginationResponse<List<Schedule>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<Schedule>>, PaginationResponse<List<ScheduleResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<PrescriptionDetailRequest, PrescriptionDetail>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PrescriptionDetail, PrescriptionDetailResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<PrescriptionDetailRequest>>, PaginationResponse<List<PrescriptionDetail>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<PrescriptionDetail>>, PaginationResponse<List<PrescriptionDetailResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<PrescriptionRequest, Prescription>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Prescription, PrescriptionResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<PrescriptionRequest>>, PaginationResponse<List<Prescription>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<Prescription>>, PaginationResponse<List<PrescriptionResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<HealthRecordRequest, HealthRecord>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<HealthRecord, HealthRecordResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<HealthRecordRequest>>, PaginationResponse<List<HealthRecord>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<HealthRecord>>, PaginationResponse<List<HealthRecordResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<MedicineRequest, Medicine>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Medicine, MedicineResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<MedicineRequest>>, PaginationResponse<List<Medicine>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<Medicine>>, PaginationResponse<List<MedicineResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<BlogRequest, Blog>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Blog, BlogResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Category, CategoryBlogResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Blog, BlogCategoryResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<BlogRequest>>, PaginationResponse<List<Blog>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<Blog>>, PaginationResponse<List<BlogResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CommentRequest, Comment>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Comment, CommentResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<CommentRequest>>, PaginationResponse<List<Comment>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<Comment>>, PaginationResponse<List<CommentResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<TagRequest, Tag>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Tag, TagResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<TagRequest>>, PaginationResponse<List<Tag>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<Tag>>, PaginationResponse<List<TagResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<FaqRequest, Faq>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Faq, FaqResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<FaqRequest>>, PaginationResponse<List<Faq>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<Faq>>, PaginationResponse<List<FaqResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CategoryRequest, Category>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Category, CategoryResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<CategoryRequest>>, PaginationResponse<List<Category>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<Category>>, PaginationResponse<List<CategoryResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<BlogTagRequest, BlogTag>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<BlogTag, BlogTagResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<BlogTagRequest>>, PaginationResponse<List<BlogTag>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<BlogTag>>, PaginationResponse<List<BlogTagResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<BranchRequest, Branch>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Branch, BranchResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<BranchRequest>>, PaginationResponse<List<Branch>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<Branch>>, PaginationResponse<List<BranchResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<BranchTypeRequest, BranchType>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<BranchType, BranchTypeResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<BranchTypeRequest>>, PaginationResponse<List<BranchType>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<BranchType>>, PaginationResponse<List<BranchTypeResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<GroupServiceRequest, GroupService>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<GroupService, GroupServiceResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<GroupServiceRequest>>, PaginationResponse<List<GroupService>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<GroupService>>, PaginationResponse<List<GroupServiceResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<GroupUrlRequest, GroupUrl>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<GroupUrl, GroupUrlResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<GroupUrlRequest>>, PaginationResponse<List<GroupUrl>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<GroupUrl>>, PaginationResponse<List<GroupUrlResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ServiceRequest, Service>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Service, ServiceResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<ServiceRequest>>, PaginationResponse<List<Service>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<Service>>, PaginationResponse<List<ServiceResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<InvoiceRequest, Invoice>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Invoice, InvoiceResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<InvoiceRequest>>, PaginationResponse<List<Invoice>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<Invoice>>, PaginationResponse<List<InvoiceResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<InvoiceDetailRequest, InvoiceDetail>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<InvoiceDetail, InvoiceDetailResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<InvoiceDetailRequest>>, PaginationResponse<List<InvoiceDetail>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<InvoiceDetail>>, PaginationResponse<List<InvoiceDetailResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ServicePriceRequest, ServicePrice>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<ServicePrice, ServicePriceResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<ServicePriceRequest>>, PaginationResponse<List<ServicePrice>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<ServicePrice>>, PaginationResponse<List<ServicePriceResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UrlRequest, Url>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Url, UrlResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<UrlRequest>>, PaginationResponse<List<Url>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<Url>>, PaginationResponse<List<UrlResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ActivityRequest, Activity>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Activity, ActivityResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<ActivityRequest>>, PaginationResponse<List<Activity>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<Activity>>, PaginationResponse<List<ActivityResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<TreatmentDetailRequest, TreatmentDetail>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<TreatmentDetail, TreatmentDetailResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<TreatmentDetailRequest>>, PaginationResponse<List<TreatmentDetail>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<TreatmentDetail>>, PaginationResponse<List<TreatmentDetailResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<TreatmentPlantRequest, TreatmentPlant>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<TreatmentPlant, TreatmentPlantResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<TreatmentPlantRequest>>, PaginationResponse<List<TreatmentPlant>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<TreatmentPlant>>, PaginationResponse<List<TreatmentPlantResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<RegisterRequest, User>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UserRequest, User>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<User, UserResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<UserRequest>>, PaginationResponse<List<User>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PaginationResponse<List<User>>, PaginationResponse<List<UserResponse>>>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
