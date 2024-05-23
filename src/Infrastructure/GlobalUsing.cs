﻿global using Core;
global using System.Linq.Expressions;
global using Infrastructure.DTOs;
global using Infrastructure.Repository;
global using Infrastructure.Services;
global using Infrastructure.Helpers;
global using Microsoft.AspNetCore.WebUtilities;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
global using Microsoft.Extensions.Caching.Memory;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using Microsoft.IdentityModel.Tokens;
global using Newtonsoft.Json;
global using System.Net;
global using System.Reflection;
global using System.Text;
global using Serilog;
global using Serilog.Sinks.Elasticsearch;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using Core.DTOs;
global using Core.Models;
global using AutoMapper;
global using BC = BCrypt.Net.BCrypt;
global using Core.Enums;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Infrastructure.Configurations;
global using Microsoft.AspNetCore.Mvc.Filters;
global using System.Security.Claims;