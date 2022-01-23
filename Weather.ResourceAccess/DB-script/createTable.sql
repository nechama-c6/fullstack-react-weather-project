SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favorite_Cities](
                [Favorite_City_Id] [int] IDENTITY(1,1) NOT NULL,
                [City_Key] [nvarchar](255) NOT NULL,
				[Is_Active][bit] NOT NULL,
PRIMARY KEY CLUSTERED
(
                [Favorite_City_Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO