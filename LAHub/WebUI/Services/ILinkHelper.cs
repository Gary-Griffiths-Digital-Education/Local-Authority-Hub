﻿using System;
using WebUI.Models;

namespace WebUI.Services;

public interface ILinkHelper
{
    string RenderListItemLink<T>(bool isSelected = false, string @class = "") where T : Models.Link;
    string RenderLink<T>(Func<string>? before = null, Func<string>? after = null, bool isSelected = false) where T : Link;
}
