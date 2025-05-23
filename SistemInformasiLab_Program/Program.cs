
﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using SistemInformasiLab_Program.Services;
using System;
using System.Collections.Generic;
using SistemInformasiLab_Program.Controllers;
using System.Threading.Tasks;

class Program
{
    static async Task Main(String[] args)
    {
        AuthController controller = new AuthController();
        await controller.ShowMenuAsync(); // Menampilkan menu  
    }
}
