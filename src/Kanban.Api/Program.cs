using Kanban.Api.Contracts.Requests;
using Kanban.Api.Persistence;
using Kanban.Application.Boards.Contracts;
using Kanban.Application.Boards.Ports;
using Kanban.Application.Boards.UseCases;


namespace Kanban
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adding Swagger to test minimal API
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Dependency injection
            builder.Services.AddSingleton<IBoardRepository, InMemoryBoardRepository>();
            builder.Services.AddTransient<CreateBoard>();
            builder.Services.AddTransient<GetBoard>();
            builder.Services.AddTransient<AddCard>();
            builder.Services.AddTransient<MoveCard>();

            var app = builder.Build();
            app.UseDefaultFiles();   
            app.UseStaticFiles();    

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseHttpsRedirection();

            // Endpoint POST /boards
            app.MapPost("/boards", async (
                CreateBoardRequest request,
                CreateBoard createBoard,
                CancellationToken ct) =>
            {
                if (string.IsNullOrWhiteSpace(request.Name))
                {
                    return Results.BadRequest("Title is required.");
                }

                var boardDto = await createBoard.Handle(request.Name, ct);
                return Results.Created($"/boards/{boardDto.Id}", boardDto);
            })
                .WithName("CreateBoard")
                .Produces<BoardDto>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest);

            // Endpoint GET /boards/{id}
            app.MapGet("/boards/{id:guid}", async (Guid id, GetBoard usecase, CancellationToken ct) =>
            {
                var boardDto = await usecase.Handle(id, ct);
                return boardDto is null ? Results.NotFound() : Results.Ok(boardDto);
            })
                .WithName("GetBoard")
                .Produces<BoardDto>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);

            //Endpoint POST /boards/{id}/cards
            app.MapPost("/boards/{id:guid}/cards", async (
                Guid id, AddCardRequest request,
                AddCard useCase,
                CancellationToken ct) =>
            {
                if (string.IsNullOrWhiteSpace(request.Title))
                    return Results.BadRequest(new { error = "Title is required" });
                var cardDto = await useCase.Handle(id, request.Title, request.Description, ct);
                return cardDto is null ? Results.NotFound() : Results.Ok(cardDto);
            })
            .WithName("AddCard")
            .Produces<BoardDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound);

            //Endpoint POST /boards/{id}/cards/{cardId}/move
            app.MapPost("/boards/{id:guid}/cards/{cardId:guid}/move", async (
                Guid id, Guid cardId, MoveCardRequest req, MoveCard useCase, CancellationToken ct) =>
            {
                if (req.TargetColumnId == Guid.Empty)
                return Results.BadRequest(new { error = "Target column is required." });

                var dto = await useCase.Handle(id, cardId, req.TargetColumnId, ct);
                return dto is null ? Results.NotFound() : Results.Ok(dto);
            })
            .WithName("MoveCard")
            .Produces<BoardDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound);

            app.Run();

        }
    }
}
