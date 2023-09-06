//Goal

//Create a Back End for a Blog Site
//Create a Front End for our Blog Site
//Deploy to Azure
//Learn about DevOps and SCRUM

Create an API for Blog. This API must handle all CRUD functions
    Create, Read,Update,Delete.

//In this app the user should be able to login. Creae an Account.
Blog page to view all the published items
Dashboard(The user profile page for them to edit, delete and add blog items)

We will talk about folder structure:

Controller//Folders
 UserController (This will handle all our user interactions)
    Login//endpoints
    Add a User//enponts
    Update a User
    Delete a User
BlogController//file
    Add Blog items// endpoint C
    GetAllBlogItems// endpoint R
    GetBlogItemsByCategory
    GetAllBlogItemsByTags
    GetBlogItemsByDate
    UpdateBlogItems// endpoin U
    DeleteBlogItems// endpont D

Model//folder
    UserModel
        int ID
        string Username
        string Salt
        string Hash 256 characters 

    BlogItemModel
        int ID
        int UserID
        string PublisherName
        string Title
        string Image
        string Description
        string Date
        string Category
        bool IsPublished
        bool IsDeleted


------------------------------ Items that will be saved to our data base DB are above --------------
    LoginModelDTO
        string Username
        string password
    CreateAccountModelDTO
        int Id = 0
        string Username
        string password
    passwordModelDTO
        string Salt 
        string Hash



Services//folder
    Context//folder

    UserService//file
        GetUsersByUsername
        Login
        Add User
        Delete User
    BlogItemService//file
        Add Blog items// functions C
    GetAllBlogItems// functions R
    GetBlogItemsByCategory
    GetAllBlogItemsByTags
    GetBlogItemsByDate
    UpdateBlogItems// functions U
    DeleteBlogItems// functions D
    GetUserById//functions

PasswordService//file   
    Hash Password
    Very Hash Password

    " Server Admin log in: academyblogAdmin Password: AcademyBlogPassword! "
