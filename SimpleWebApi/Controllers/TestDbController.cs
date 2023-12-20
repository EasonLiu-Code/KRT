﻿using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Application.IAppService;
using SimpleWebApi.Infrastructure.Entities.Test;

namespace SimpleWebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class TestDbController:ControllerBase
{
    private readonly ITestDbAppService _testDbAppService;

    public TestDbController(ITestDbAppService testDbAppService)
    {
        _testDbAppService = testDbAppService;
    }

    [HttpPost]
    public async Task<bool> InsertData(TestDbDto testDb)
    {
        return await _testDbAppService.TestInsertData(testDb);
    }
}