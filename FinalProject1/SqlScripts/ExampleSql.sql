IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250804004514_TeamModelUpdate'
)
BEGIN
    CREATE TABLE [Teams] (
        [Id] bigint NOT NULL IDENTITY,
        [TeamMember] nvarchar(max) NOT NULL,
        [BirthDate] date NOT NULL,
        [CollegeProgram] nvarchar(max) NOT NULL,
        [Year] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Teams] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250804004514_TeamModelUpdate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250804004514_TeamModelUpdate', N'8.0.18');
END;
GO

COMMIT;
GO

