## Project Overview :
  This project is a demonstration of using Entity Framework (EF) Core for managing and querying a relational database in C#. 
  It showcases different querying techniques like LINQ queries, join operations, and executing stored procedures.

## Project Structure :
 1- ApplicationDbContext.cs: This is the heart of the project where the database context is defined. 
    It includes DbSet properties that represent the tables, and OnModelCreating method to configure entity mappings and global query filters.
    
 2- Query Features:
        LINQ Queries: Demonstrates inner and left joins between books, authors, and nationalities.
        Stored Procedures: Executes SQL stored procedures like prc_GetAllBooks, prc_GetBookById, and prc_GetBooksWithAuthors.
        Global Query Filters: Applies filters to exclude specific entries globally (e.g., filtering authors by nationality).
        Ignore Query Filters: Disables the query filter selectively.

## Usage :
   1- Running the Queries: The Program.cs contains sample executions of various queries. Running the program will print the results of joins, stored procedures, and filtered queries in the console.
   2- Database Interaction: Make sure the SQL Server instance is running, and tables are properly set up using migrations or SQL scripts.
