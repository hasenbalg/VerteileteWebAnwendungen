using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VWW_Project.Controllers
{
    public abstract class BaseDatabaseController : Controller
    {
        private DbModelContainer db;
        protected DbModelContainer Db
        {
            get
            {
                if (this.db == null)
                {
                    this.db = new DbModelContainer();
                }
                return this.db;
            }
        }

        public BaseDatabaseController() { }
        public BaseDatabaseController(DbModelContainer db)
            : this()
        {
            this.db = db;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
                this.db = null;
            }
            base.Dispose(disposing);
        }
    }
}