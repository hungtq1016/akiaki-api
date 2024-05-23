namespace Infrastructure.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options) { }

        public DbSet<Assignment> Assignments => Set<Assignment>();
        public DbSet<Blog> Blogs => Set<Blog>();
        public DbSet<Blog> BlogTags => Set<Blog>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<GroupService> GroupServices => Set<GroupService>();
        public DbSet<Group> Groups => Set<Group>();
        public DbSet<Image> Images => Set<Image>();
        public DbSet<Language> Languages => Set<Language>();
        public DbSet<Locale> Locales => Set<Locale>();
        public DbSet<Schedule> Schedules => Set<Schedule>();
        public DbSet<LocaleKey> LocaleKeys => Set<LocaleKey>();
        public DbSet<Medicine> Medicines => Set<Medicine>();
        public DbSet<HealthRecord> HealthRecords => Set<HealthRecord>();
        public DbSet<OTP> OTPs => Set<OTP>();
        public DbSet<SendEmail> SendEmails => Set<SendEmail>();
        public DbSet<Permission> Permissions => Set<Permission>();
        public DbSet<Prescription> Prescriptions => Set<Prescription>();
        public DbSet<PrescriptionDetail> PrescriptionDetails => Set<PrescriptionDetail>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Service> Services => Set<Service>();
        public DbSet<Token> Tokens => Set<Token>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Branch> Branches => Set<Branch>();
        public DbSet<BranchType> BranchTypes => Set<BranchType>();
        public DbSet<Faq> Faqs => Set<Faq>();
        public DbSet<Url> Urls => Set<Url>();
        public DbSet<GroupUrl> GroupUrls => Set<GroupUrl>();
        public DbSet<Invoice> Invoices => Set<Invoice>();
        public DbSet<InvoiceDetail> InvoiceDetails => Set<InvoiceDetail>();
        public DbSet<ServicePrice> ServicePrices => Set<ServicePrice>();
        public DbSet<TreatmentPlant> TreatmentPlants => Set<TreatmentPlant>();
        public DbSet<TreatmentDetail> TreatmentDetails => Set<TreatmentDetail>();
        public DbSet<Activity> Activities => Set<Activity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AssignmentConfiguration());
            modelBuilder.ApplyConfiguration(new SendEmailConfiguration());
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new BlogTagConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new GroupServiceConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new LocaleConfiguration());
            modelBuilder.ApplyConfiguration(new LocaleKeyConfiguration());
            modelBuilder.ApplyConfiguration(new MedicineConfiguration());
            modelBuilder.ApplyConfiguration(new HealthRecordConfiguration());
            modelBuilder.ApplyConfiguration(new OTPConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new PrescriptionConfiguration());
            modelBuilder.ApplyConfiguration(new PrescriptionDetailConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new TokenConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BranchConfiguration());
            modelBuilder.ApplyConfiguration(new BranchTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UrlConfiguration());
            modelBuilder.ApplyConfiguration(new GroupUrlConfiguration());
            modelBuilder.ApplyConfiguration(new FaqConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ServicePriceConfiguration()); 
            modelBuilder.ApplyConfiguration(new TreatmentDetailConfiguration()); 
            modelBuilder.ApplyConfiguration(new TreatmentPlantConfiguration()); 
            modelBuilder.ApplyConfiguration(new ActivityConfiguration());

        }
    }
}
