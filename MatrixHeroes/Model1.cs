namespace MatrixHeroes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class Model1 : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MatrixHeroes.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public Model1()
            : base("name=Model1")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Hero> Heroes { get; set; }
        public virtual DbSet<Ability> Abilities { get; set; }
        public virtual DbSet<SuitColor> SuitColors { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
    }
    public class Ability
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MyProperty { get; set; }

        public Ability ability { get; set; }

        public SuitColor SuitCol { get; set; }
        public DateTime StartedTrain { get; set; }
        public string SuitColors { get; set; }
        public decimal StartingPower { get; set; }
        public decimal CurrentPower { get; set; }

    }
    public class Training
    {
        public Training()
        {
            startDate = DateTime.Now;
        }
        public int Id { get; set; }
        public Hero hero { get; set; }
        public Trainer trainer { get; set; }

        private DateTime startDate;
    }
    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class SuitColor
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "COnfirm password should be same as password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lase name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
    }

    }
