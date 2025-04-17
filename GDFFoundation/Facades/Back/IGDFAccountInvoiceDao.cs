

using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a data access interface for handling GDFAccountInvoice objects.
    /// </summary>
    public interface IGDFAccountInvoiceDao : IGDFDao
    {
        /// <summary>
        /// Creates a new GDFAccountInvoice object.
        /// </summary>
        /// <param name="sEnvironment">The environment kind of the account invoice.</param>
        /// <param name="sProjectReference">The project ID of the account invoice.</param>
        /// <param name="sModel">The account invoice model to create.</param>
        /// <returns>The created GDFAccountInvoice object.</returns>
        public GDFAccountInvoice Create(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFAccountInvoice sModel);

        /// <summary>
        /// Updates the GDFAccountInvoice object in the specified environment and project with the provided model.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sModel">The GDFAccountInvoice model.</param>
        /// <returns>The updated GDFAccountInvoice object.</returns>
        public GDFAccountInvoice Update(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFAccountInvoice sModel);

        /// <summary>
        /// Deletes an account invoice from the database.
        /// </summary>
        /// <param name="sEnvironment">The environment kind of the account invoice.</param>
        /// <param name="sProjectReference">The project ID of the account invoice.</param>
        /// <param name="sReference">The reference of the account invoice.</param>
        public void Delete(GDFEnvironmentKind sEnvironment, long sProjectReference, long sReference);

        /// <summary>
        /// Retrieves a list of GDFAccountInvoice objects that match the specified environment and project ID.
        /// </summary>
        /// <param name="sEnvironment">The environment (e.g. Development, PlayTest, Production).</param>
        /// <param name="sProjectReference">The ID of the project.</param>
        /// <returns>A list of GDFAccountInvoice objects that match the specified environment and project ID.</returns>
        public List<GDFAccountInvoice> FindAll(GDFEnvironmentKind sEnvironment, long sProjectReference);

        /// <summary>
        /// Find all modified account invoices based on the given environment, project ID, and sync date.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sSyncDate">The sync date.</param>
        /// <returns>The list of modified account invoices.</returns>
        public List<GDFAccountInvoice> FindAllModified(GDFEnvironmentKind sEnvironment, long sProjectReference, long sSyncDate);

        /// <summary>
        /// Inserts or updates a GDFAccountInvoice object in the specified environment and project.
        /// </summary>
        /// <param name="sEnvironment">The environment in which to insert or update the object.</param>
        /// <param name="sProjectReference">The ID of the project.</param>
        /// <param name="sModel">The GDFAccountInvoice object to insert or update.</param>
        /// <returns>The inserted or updated GDFAccountInvoice object.</returns>
        public GDFAccountInvoice InsertOrUpdate(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFAccountInvoice sModel);

        /// <summary>
        /// Retrieves a list of GDFAccountInvoice objects based on specified parameters.
        /// </summary>
        /// <param name="sEnvironment">The GDFEnvironmentKind representing the environment.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sWhereClause">The list of GDFDatabaseWhereModel objects representing the where clause.</param>
        /// <returns>A list of GDFAccountInvoice objects.</returns>
        public List<GDFAccountInvoice> GetBy(GDFEnvironmentKind sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause);
    }
}

