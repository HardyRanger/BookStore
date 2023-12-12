using Microsoft.AspNetCore.Identity;
using BookStore.Models;
using System;
using BookStore.Data.Staic;

namespace BookStore.Data
{
    public class BookInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            { 
                var context = serviceScope.ServiceProvider.GetService<BookContext>();

                context.Database.EnsureCreated();

                //Category
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<Category>()
                    {
                        new Category()
                        {
                            Name = "Horror"

                        },
                        new Category()
                        {
                            Name = "Comedy"

                        },
                          new Category()
                        {
                            Name = "Drama",

                        },
                            new Category()
                        {
                            Name = "Romantic",

                        },
                              new Category()
                        {
                            Name = "Thriller",

                        },

                    });
                    context.SaveChanges();
                }
                //Author
                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(new List<Author>()
                    {
                        new Author()
                        {
                            FullName = "Shubhra Gupta",
                            Bio = "This is the Bio of the first author",
                            ProfilePictureURL = "https://img.etimg.com/thumb/width-1200,height-1200,imgsize-86322,resizemode-75,msid-96814596/magazines/panache/a-life-in-movie-new-book-to-offer-compelling-account-of-irrfan-khans-iconic-life.jpg"

                        },
                        new Author()
                        {
                            FullName = "Kaki Madhava Rao",
                            Bio = "This is the Bio of the second author",
                            ProfilePictureURL = "https://bl-i.thgim.com/public/news/8jcnm7/article66327252.ece/alternates/LANDSCAPE_1200/emmesco.jpg"
                        },
                         new Author()
                        {
                            FullName = "Shashi Tharoor",
                            Bio = "This is the Bio of the third author",
                            ProfilePictureURL = "https://media.cnn.com/api/v1/images/stellar/prod/180605181305-shashi-tharoor-2016.jpg?q=x_38,y_33,h_1659,w_2948,c_crop/h_720,w_1280"
                        },
                          new Author()
                        {
                            FullName = "Author 4",
                            Bio = "This is the Bio of the fourth author",
                            ProfilePictureURL = "https://media.cnn.com/api/v1/images/stellar/prod/180605181305-shashi-tharoor-2016.jpg?q=x_38,y_33,h_1659,w_2948,c_crop/h_720,w_1280"
                        },
                           new Author()
                        {
                            FullName = "Author 5",
                            Bio = "This is the Bio of the fifth author",
                            ProfilePictureURL = "https://media.cnn.com/api/v1/images/stellar/prod/180605181305-shashi-tharoor-2016.jpg?q=x_38,y_33,h_1659,w_2948,c_crop/h_720,w_1280"
                        },

                    });
                    context.SaveChanges();
                }

                //Movies
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new List<Books>()
                    {
                        new Books()
                        {
                            Name = "Life",
                            Description = "This is the  description Life Book",
                            Price = 39.50,
                            ImageURL = "https://edit.org/photos/img/blog/t9i-edit-book-covers-online.jpg-840.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CatId = 3,
                            AuthorId = 3,

                        },
                        new Books()
                        {
                            Name = "Old Man",
                            Description = "Old man and the seaaa",
                            Price = 29.50,
                            ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRS9C7A0CzQYsuMl348G5HMJWcbQX1OEhVtG8gJe4XOCbTnesu1u0uoCGvhSpfMonBxMA8&usqp=CAU",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CatId = 1,
                            AuthorId = 1,

                        },
                        new Books()
                        {
                            Name = "Ghost",
                            Description = "This is the Ghost Book description",
                            Price = 39.50,
                            ImageURL = "https://marketplace.canva.com/EAFSw3t08lg/1/0/1003w/canva-black-mystery-novel-book-cover-zRJPsYKih38.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CatId = 4,
                            AuthorId = 4,

                        },
                        new Books()
                        {
                            Name = "Race",
                            Description = "This is the description of Race",
                            Price = 39.50,
                            ImageURL = "https://cdn.pixabay.com/photo/2019/05/10/23/54/book-cover-4194807_640.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CatId = 1,
                            AuthorId = 2,

                        },
                        new Books()
                        {
                            Name = "Scoob",
                            Description = "This is the description of Scoob ",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CatId = 1,
                            AuthorId = 3,

                        },
                        new Books()
                        {
                            Name = "Thread ",
                            Description = "This is the  description of Thread",
                            Price = 39.50,
                            ImageURL = "https://marketplace.canva.com/EAFMlxqVi1U/1/0/1003w/canva-black-mystery-novel-book-cover-DqHX0DWBxm8.jpg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CatId = 1,
                            AuthorId = 5,

                        }
                    });
                    context.SaveChanges();
                }


            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin",
                        UserName = "admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Admin@123");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "akshay@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Akshay Kumar",
                        UserName = "Akshay",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Akshay@123");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }


}


