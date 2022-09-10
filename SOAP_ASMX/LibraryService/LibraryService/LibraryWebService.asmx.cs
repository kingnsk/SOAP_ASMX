﻿using LibraryService.Models;
using LibraryService.Services;
using LibraryService.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace LibraryService
{
    /// <summary>
    /// Сводное описание для LibraryWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class LibraryWebService : System.Web.Services.WebService
    {
        #region Services

        private readonly ILibraryRepositoryService _libraryRepositoryService;

        #endregion
        public LibraryWebService()
        {
            _libraryRepositoryService = new LibraryRepository(new LibraryDatabaseContext());
        }

        [WebMethod]
        public Book[] GetBookByTitle(string title)
        {
            return _libraryRepositoryService.GetByTitle(title).ToArray();
        }

        [WebMethod]
        public Book[] GetBookByAuthor(string author)
        {
            return _libraryRepositoryService.GetByAuthor(author).ToArray();
        }

        [WebMethod]
        public Book[] GetBookByCategory(string category)
        {
            return _libraryRepositoryService.GetByCategory(category).ToArray();
        }

    }
}
