﻿using WebUI.Models;

namespace WebUI.Services;

public interface IUrlHelper
{
    string GetPath(string baseUrl, string path = "");
    string GetPath(IUserContext userContext, string baseUrl, string path = "", string prefix = "accounts");
}
