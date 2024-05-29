using Microsoft.ReportingServices.Diagnostics.Utilities;
using Microsoft.ReportingServices.Interfaces;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XtremePharmacyManager;
using XtremePharmacyManager.DataEntities;

namespace XtremePharmacyManager
{
    public enum BulkOperationType
    {
        DEFAULT,
        ADD = 1,
        UPDATE = 2,
        DELETE = 3,
        CUSTOM = 4
    }

    public interface BulkOperationTargetUpdater<T>
    {
        void UpdateTargetObject(T obj);
    }

    public class BulkOperation<T> :BulkOperationTargetUpdater<T>, IDisposable//This is the class to derive all bulk operations from and its tasks will be overriden
    {
        BulkOperationType type;
        User current_user;
        T target_object;
        string operation_name = "";
        string success_message = "";
        string error_message = "";
        string stack_trace = "";
        int error_code = -1;
        int inner_error_code = -1;
        bool is_silent = true;


        public T TargetObject { get { return target_object; } }

        public User CurrentUser { get { return current_user; } set { current_user = value; } }
        public BulkOperationType OperationType { get { return type; } set { type = value; } }
        public string OperationName { get { return operation_name; } set { operation_name = value; } }
        public string SuccessMessage { get { return success_message; } set { success_message = value; } }
        public string ErrorMessage { get { return error_message; } set { error_message = value; } }
        public string StackTrace { get { return stack_trace; } set { stack_trace = value; } }
        public bool IsSilent { get { return is_silent; } set { is_silent = value; } }
        public int ErrorCode {  get { return error_code; } set { error_code = value; } }
        public int InnerErrorCode { get { return inner_error_code; } set { inner_error_code = value; } }

        public BulkOperation()
        {
            type = BulkOperationType.DEFAULT;
            target_object = (T)Activator.CreateInstance(typeof(T));
            is_silent = true;
            operation_name = $"{type} operation on {target_object.GetType()}";
        }
        public BulkOperation(BulkOperationType optype,T obj, bool is_silent)
        {
            type = optype;
            if (obj != null)  
            {
                UpdateTargetObject(obj);
            }
            this.is_silent = is_silent;
            operation_name = $"{type} operation on {target_object.GetType()}";
        }

        public virtual void UpdateName()
        {
            operation_name = $"{type} operation on {target_object.GetType()}";
        }

        

        public  async Task<bool> Execute()
        {
            bool result = false;
            switch(type)
            {
                case BulkOperationType.DEFAULT: //default is invalid
                    result = false;
                    break;
                case BulkOperationType.ADD: //add task
                    result = await createTask();
                    break;
                case BulkOperationType.UPDATE: //update task
                    result = await updateTask();
                    break;
                case BulkOperationType.DELETE: //delete task
                    result = await deleteTask();
                    break;
                case BulkOperationType.CUSTOM: //custom tasks that aren't only create, update or delete but more complex
                    result = await customTask();
                    break;
                default: //again, an invalid value
                    result = false;
                    break;
            }
            return result;
        }

        protected virtual async Task<bool> createTask()
        {
            bool result = false;
            try
            {
                result = true;
                success_message = "Sample bulk create task executed successfully.";
                Debug.WriteLineIf(result, success_message);
            }
            catch (Exception ex)
            {
                if (!is_silent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                error_message = ex.Message + "\n";
                error_code = ex.HResult;
                stack_trace = ex.StackTrace + "\n";
                if(ex.InnerException != null)
                {
                    inner_error_code = ex.InnerException.HResult;
                    error_message += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    stack_trace += ex.InnerException.StackTrace + "\n";
                }
            }
            return result;
        }

        protected virtual async Task<bool> updateTask()
        {
            bool result = false;
            try
            {
                result = true;
                success_message = "Sample bulk update task executed successfully.";
                Debug.WriteLineIf(result, success_message);
            }
            catch (Exception ex)
            {
                if (!is_silent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                error_message = ex.Message + "\n";
                error_code = ex.HResult;
                stack_trace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    inner_error_code = ex.InnerException.HResult;
                    error_message += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    stack_trace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        protected virtual async Task<bool> deleteTask()
        {
            bool result = false;
            try
            {
                result = true;
                success_message = "Sample bulk update task executed successfully.";
                Debug.WriteLineIf(result, success_message);
            }
            catch (Exception ex)
            {
                if (!is_silent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                error_message = ex.Message + "\n";
                error_code = ex.HResult;
                stack_trace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    inner_error_code = ex.InnerException.HResult;
                    error_message += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    stack_trace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        protected virtual async Task<bool> customTask()
        {
            bool result = false;
            try
            {
                result = true;
                success_message = "Sample custom bulk task executed successfully.";
                Debug.WriteLineIf(result, success_message);
            }
            catch (Exception ex)
            {
                if (!is_silent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                error_message = ex.Message + "\n";
                error_code = ex.HResult;
                stack_trace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    inner_error_code = ex.InnerException.HResult;
                    error_message += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    stack_trace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        public void UpdateTargetObject(T obj)
        {
            if(target_object == null)
            {
                target_object = (T)Activator.CreateInstance(typeof(T));
            }
            Type objectType = TargetObject.GetType();
            Type otherobjbasetype = obj.GetType().GetTypeInfo().BaseType;
            try
            {
                target_object = (T)Activator.CreateInstance(typeof(T));
                if (objectType == otherobjbasetype || objectType == obj.GetType())
                {
                    foreach (var property in objectType.GetProperties())
                    {
                        var current_target_value = property.GetValue(target_object, null);
                        var current_other_object_value = property.GetValue(obj, null);
                        property.SetValue(target_object, current_other_object_value, null);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}:::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ex.InnerException != null)
                {
                    MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Dispose()
        {
            is_silent = false;
            inner_error_code = -1;
            error_code = -1;
            if(stack_trace != null)
            {
                stack_trace = null;
            }
            if(error_message != null)
            {
                error_message = null;
            }
            if(success_message != null)
            {
                success_message = null;
            }
            if(operation_name != null)
            {
                operation_name = null;
            }
            if(target_object != null)
            {
                target_object = default(T);
            }
            if(current_user != null)
            {
                current_user = null;
            }
            type = BulkOperationType.DEFAULT;
        }
    }

    public class BulkUserOperation : BulkOperation<User>
    {
        static Entities entities;

        public BulkUserOperation() :base()
        {

        }

        public BulkUserOperation(BulkOperationType type,ref Entities ent, User target_user, bool is_silent) : base(type, target_user, is_silent)
        {
            entities = ent;
            base.OperationName = $"{type} operation on {base.TargetObject.GetType()} with ID: {base.TargetObject.ID}";
        }


        public override void UpdateName()
        {
            base.OperationName = $"{base.OperationType} operation on {base.TargetObject.GetType()} with ID: {base.TargetObject.ID}";
        }

        protected override async Task<bool> createTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "User has been added.";
                if (base.CurrentUser != null && base.CurrentUser.UserRole == 0)
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.AddUser(base.TargetObject.UserName, base.TargetObject.UserPassword, base.TargetObject.UserDisplayName, base.TargetObject.UserBirthDate, base.TargetObject.UserPhone,
                                         base.TargetObject.UserEmail, base.TargetObject.UserAddress, base.TargetObject.UserProfilePic, base.TargetObject.UserBalance, base.TargetObject.UserDiagnose,
                                         base.TargetObject.UserRole);
                        if (entities.Users.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.Users.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                        //update the view on add, update or delete if it hasn't been updated(probably will not be found on add
                        //or delete and yeah
                        if (base.TargetObject.UserRole == 0 || base.TargetObject.UserRole == 1)
                        {
                            //retrieve the data and if it exists reload it from the database, if not, do nothing
                            EmployeeView current_emp_view = entities.EmployeeViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                            if (current_emp_view != null)
                            {
                                entities.Entry(current_emp_view).Reload();
                            }
                        }
                        else if (base.TargetObject.UserRole == 2)
                        {
                            //retrieve the data and if it exists reload it from the database, if not, do nothing
                            ClientView current_cl_view = entities.ClientViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                            if (current_cl_view != null)
                            {
                                entities.Entry(current_cl_view).Reload();
                            }
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for users is done only by the administrators of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}:::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        protected override async Task<bool> updateTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "User has been updated.";
                if (base.CurrentUser != null && base.CurrentUser.UserRole == 0)
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.UpdateUserByID(base.TargetObject.ID, base.TargetObject.UserName, base.TargetObject.UserPassword, base.TargetObject.UserDisplayName, base.TargetObject.UserBirthDate, base.TargetObject.UserPhone,
                                         base.TargetObject.UserEmail, base.TargetObject.UserAddress, base.TargetObject.UserProfilePic, base.TargetObject.UserBalance, base.TargetObject.UserDiagnose,
                                         base.TargetObject.UserRole);
                        if (entities.Users.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.Users.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                        //reload its data on the view as well if it is existing
                        //update the view on add, update or delete if it hasn't been updated(probably will not be found on add
                        //or delete and yeah
                        if (base.TargetObject.UserRole == 0 || base.TargetObject.UserRole == 1)
                        {
                            //retrieve the data and if it exists reload it from the database, if not, do nothing
                            EmployeeView current_emp_view = entities.EmployeeViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                            if (current_emp_view != null)
                            {
                                entities.Entry(current_emp_view).Reload();
                            }
                        }
                        else if (base.TargetObject.UserRole == 2)
                        {
                            //retrieve the data and if it exists reload it from the database, if not, do nothing
                            ClientView current_cl_view = entities.ClientViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                            if (current_cl_view != null)
                            {
                                entities.Entry(current_cl_view).Reload();
                            }
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for users is done only by the administrators of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        protected override async Task<bool> deleteTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "User has been deleted.";
                if (base.CurrentUser != null && base.CurrentUser.UserRole == 0)
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.DeleteUserByID(base.TargetObject.ID);
                        if (entities.Users.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.Users.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                        //no need to reload nonexistent or just added entries but if the view still contains them
                        //better reload them
                        //update the view on add, update or delete if it hasn't been updated(probably will not be found on add
                        //or delete and yeah
                        if (base.TargetObject.UserRole == 0 || base.TargetObject.UserRole == 1)
                        {
                            //retrieve the data and if it exists reload it from the database, if not, do nothing
                            EmployeeView current_emp_view = entities.EmployeeViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                            if (current_emp_view != null)
                            {
                                entities.Entry(current_emp_view).Reload();
                            }
                        }
                        else if (base.TargetObject.UserRole == 2)
                        {
                            //retrieve the data and if it exists reload it from the database, if not, do nothing
                            ClientView current_cl_view = entities.ClientViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                            if (current_cl_view != null)
                            {
                                entities.Entry(current_cl_view).Reload();
                            }
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for users is done only by the administrators of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        //No custom task by default, if you want custom tasks inherit from this class

    }

    public class BulkProductBrandOperation : BulkOperation<ProductBrand>
    {
        static Entities entities;

        public BulkProductBrandOperation() : base()
        {

        }

        public BulkProductBrandOperation(BulkOperationType type, ref Entities ent, ProductBrand target_brand, bool is_silent) : base(type, target_brand, is_silent)
        {
            entities = ent;
            base.OperationName = $"{type} operation on {base.TargetObject.GetType()} with ID: {base.TargetObject.ID}";
        }

        public override void UpdateName()
        {
            base.OperationName = $"{base.OperationType} operation on {base.TargetObject.GetType()} with ID: {base.TargetObject.ID}";
        }

        protected override async Task<bool> createTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "Product Brand has been added.";
                if (base.CurrentUser != null && base.CurrentUser.UserRole == 0)
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.AddBrand(base.TargetObject.BrandName);
                        if (entities.ProductBrands.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.ProductBrands.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                        //find the entry that corresponds to the entry in the original table and reload it so it is updated in the model
                        ExtendedBrandsView prb_view = entities.ExtendedBrandsViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                        if (prb_view != null)
                        {
                            entities.Entry(prb_view).Reload();
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for product brands is done only by the administrators of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        protected override async Task<bool> updateTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "Product Brand has been updated.";
                if (base.CurrentUser != null && base.CurrentUser.UserRole == 0)
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.UpdateBrandByID(base.TargetObject.ID, base.TargetObject.BrandName);
                        if (entities.ProductBrands.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.ProductBrands.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                        //find the entry that corresponds to the entry in the original table and reload it so it is updated in the model
                        ExtendedBrandsView prb_view = entities.ExtendedBrandsViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                        if (prb_view != null)
                        {
                            entities.Entry(prb_view).Reload();
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for product brands is done only by the administrators of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        protected override async Task<bool> deleteTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "Product Brand has been deleted.";
                if (base.CurrentUser != null && base.CurrentUser.UserRole == 0)
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.DeleteBrandByID(base.TargetObject.ID);
                        if (entities.ProductBrands.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.ProductBrands.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                        //find the entry that corresponds to the entry in the original table and reload it so it is updated in the model
                        ExtendedBrandsView prb_view = entities.ExtendedBrandsViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                        if (prb_view != null)
                        {
                            entities.Entry(prb_view).Reload();
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for product brands is done only by the administrators of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        //No custom task by default, if you want custom tasks inherit from this class

    }

    public class BulkProductVendorOperation : BulkOperation<ProductVendor>
    {
        static Entities entities;

        public BulkProductVendorOperation() : base()
        {

        }

        public BulkProductVendorOperation(BulkOperationType type, ref Entities ent, ProductVendor target_vendor, bool is_silent) : base(type, target_vendor, is_silent)
        {
            entities = ent;
            base.OperationName = $"{type} operation on {base.TargetObject.GetType()} with ID: {base.TargetObject.ID}";
        }

        public override void UpdateName()
        {
            base.OperationName = $"{base.OperationType} operation on {base.TargetObject.GetType()} with ID: {base.TargetObject.ID}";
        }

        protected override async Task<bool> createTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "Product Vendor has been added.";
                if (base.CurrentUser != null && base.CurrentUser.UserRole == 0)
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.AddVendor(base.TargetObject.VendorName);
                        if (entities.ProductVendors.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.ProductVendors.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                        //find the entry that corresponds to the entry in the original table and reload it so it is updated in the model
                        ExtendedVendorsView prv_view = entities.ExtendedVendorsViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                        if (prv_view != null)
                        {
                            entities.Entry(prv_view).Reload();
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for product vendors is done only by the administrators of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        protected override async Task<bool> updateTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "Product Vendor has been updated.";
                if (base.CurrentUser != null && base.CurrentUser.UserRole == 0)
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.UpdateVendorByID(base.TargetObject.ID, base.TargetObject.VendorName);
                        if (entities.ProductVendors.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.ProductVendors.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                        //find the entry that corresponds to the entry in the original table and reload it so it is updated in the model
                        ExtendedVendorsView prv_view = entities.ExtendedVendorsViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                        if (prv_view != null)
                        {
                            entities.Entry(prv_view).Reload();
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for product vendors is done only by the administrators of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        protected override async Task<bool> deleteTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "Product Vendor has been deleted.";
                if (base.CurrentUser != null && base.CurrentUser.UserRole == 0)
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.DeleteVendorByID(base.TargetObject.ID);
                        if (entities.ProductVendors.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.ProductVendors.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                        //find the entry that corresponds to the entry in the original table and reload it so it is updated in the model
                        ExtendedVendorsView prv_view = entities.ExtendedVendorsViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                        if (prv_view != null)
                        {
                            entities.Entry(prv_view).Reload();
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for product vendors is done only by the administrators of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        //No custom task by default, if you want custom tasks inherit from this class

    }

    public class BulkPaymentMethodOperation : BulkOperation<PaymentMethod>
    {
        static Entities entities;

        public BulkPaymentMethodOperation() : base()
        {

        }

        public BulkPaymentMethodOperation(BulkOperationType type, ref Entities ent, PaymentMethod target_method, bool is_silent) : base(type, target_method, is_silent)
        {
            entities = ent;
            base.OperationName = $"{type} operation on {base.TargetObject.GetType()} with ID: {base.TargetObject.ID}";
        }

        public override void UpdateName()
        {
            base.OperationName = $"{base.OperationType} operation on {base.TargetObject.GetType()} with ID: {base.TargetObject.ID}";
        }

        protected override async Task<bool> createTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "Payment Method has been added.";
                if (base.CurrentUser != null && base.CurrentUser.UserRole == 0)
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.AddPaymentMethod(base.TargetObject.MethodName);
                        if (entities.PaymentMethods.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.PaymentMethods.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                        //if you find a data from the table entry the operation was performed on in the views reload the view in the model
                        ExtendedPaymentMethodsView pm_view = entities.ExtendedPaymentMethodsViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                        if (pm_view != null)
                        {
                            entities.Entry(pm_view).Reload();
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for payment methods is done only by the administrators of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        protected override async Task<bool> updateTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "Payment Method has been updated.";
                if (base.CurrentUser != null && base.CurrentUser.UserRole == 0)
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.UpdatePaymentMethodByID(base.TargetObject.ID, base.TargetObject.MethodName);
                        if (entities.PaymentMethods.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.PaymentMethods.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                        //if you find a data from the table entry the operation was performed on in the views reload the view in the model
                        ExtendedPaymentMethodsView pm_view = entities.ExtendedPaymentMethodsViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                        if (pm_view != null)
                        {
                            entities.Entry(pm_view).Reload();
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for payment methods is done only by the administrators of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
                return result;
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        protected override async Task<bool> deleteTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "Payment Method has been deleted.";
                if (base.CurrentUser != null && base.CurrentUser.UserRole == 0)
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.DeletePaymentMethodByID(base.TargetObject.ID);
                        if (entities.PaymentMethods.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.PaymentMethods.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                        //if you find a data from the table entry the operation was performed on in the views reload the view in the model
                        ExtendedPaymentMethodsView pm_view = entities.ExtendedPaymentMethodsViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                        if (pm_view != null)
                        {
                            entities.Entry(pm_view).Reload();
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for payment methods is done only by the administrators of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        //No custom task by default, if you want custom tasks inherit from this class

    }

    public class BulkDeliveryServiceOperation : BulkOperation<DeliveryService>
    {
        static Entities entities;

        public BulkDeliveryServiceOperation() : base()
        {

        }

        public BulkDeliveryServiceOperation(BulkOperationType type, ref Entities ent, DeliveryService target_service, bool is_silent) : base(type, target_service, is_silent)
        {
            entities = ent;
            base.OperationName = $"{type} operation on {base.TargetObject.GetType()} with ID: {base.TargetObject.ID}";
        }

        public override void UpdateName()
        {
            base.OperationName = $"{base.OperationType} operation on {base.TargetObject.GetType()} with ID: {base.TargetObject.ID}";
        }

        protected override async Task<bool> createTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "Delivery Service has been added.";
                if (base.CurrentUser != null && base.CurrentUser.UserRole == 0)
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.AddDeliveryService(base.TargetObject.ServiceName, base.TargetObject.ServicePrice);
                        if (entities.DeliveryServices.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.DeliveryServices.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                        //in whatever this operation is that affects something from the table find the ID of that in the view of the database
                        //and sync it with the model in case the database doesn't sync it automatically with the model
                        ExtendedDeliveryServicesView ds_view = entities.ExtendedDeliveryServicesViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                        if (ds_view != null)
                        {
                            entities.Entry(ds_view).Reload();
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for delivery services is done only by the administrators of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        protected override async Task<bool> updateTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "Delivery Service has been updated.";
                if (base.CurrentUser != null && base.CurrentUser.UserRole == 0)
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.UpdateDeliveryServiceByID(base.TargetObject.ID, base.TargetObject.ServiceName, base.TargetObject.ServicePrice);
                        if (entities.DeliveryServices.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.DeliveryServices.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                        //in whatever this operation is that affects something from the table find the ID of that in the view of the database
                        //and sync it with the model in case the database doesn't sync it automatically with the model
                        ExtendedDeliveryServicesView ds_view = entities.ExtendedDeliveryServicesViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                        if (ds_view != null)
                        {
                            entities.Entry(ds_view).Reload();
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for delivery services is done only by the administrators of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        protected override async Task<bool> deleteTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "Delivery Service has been deleted.";
                if (base.CurrentUser != null && base.CurrentUser.UserRole == 0)
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.DeleteDeliveryServiceByID(base.TargetObject.ID);
                        if (entities.DeliveryServices.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.DeliveryServices.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                        //in whatever this operation is that affects something from the table find the ID of that in the view of the database
                        //and sync it with the model in case the database doesn't sync it automatically with the model
                        ExtendedDeliveryServicesView ds_view = entities.ExtendedDeliveryServicesViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                        if (ds_view != null)
                        {
                            entities.Entry(ds_view).Reload();
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for delivery services is done only by the administrators of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        //No custom task by default, if you want custom tasks inherit from this class

    }

    public class BulkProductOperation : BulkOperation<Product>
    {
        static Entities entities;

        public BulkProductOperation() : base()
        {

        }

        public BulkProductOperation(BulkOperationType type, ref Entities ent, Product target_product, bool is_silent) : base(type, target_product, is_silent)
        {
            entities = ent;
            base.OperationName = $"{type} operation on {base.TargetObject.GetType()} with ID: {base.TargetObject.ID}";
        }

        public override void UpdateName()
        {
            base.OperationName = $"{base.OperationType} operation on {base.TargetObject.GetType()} with ID: {base.TargetObject.ID}";
        }

        protected override async Task<bool> createTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "Product has been added.";
                if (base.CurrentUser != null && base.CurrentUser.UserRole == 0)
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.AddProduct(base.TargetObject.ProductName, base.TargetObject.BrandID, base.TargetObject.VendorID, base.TargetObject.ProductDescription,
                            base.TargetObject.ProductQuantity, base.TargetObject.ProductPrice, base.TargetObject.ProductExpiryDate,
                            base.TargetObject.ProductRegNum, base.TargetObject.ProductPartNum, base.TargetObject.ProductStorageLocation);
                        if (entities.Products.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.Products.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                        //Find this entry in the view that corresponds to the entry in the table and if it is found reload it, if not then not
                        ExtendedProductView pr_view = entities.ExtendedProductViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                        if (pr_view != null)
                        {
                            entities.Entry(pr_view).Reload();
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for products is done only by the administrators of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        protected override async Task<bool> updateTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "Product has been updated.";
                if (base.CurrentUser != null && base.CurrentUser.UserRole == 0)
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.UpdateProductByID(base.TargetObject.ID, base.TargetObject.ProductName, base.TargetObject.BrandID, base.TargetObject.VendorID, base.TargetObject.ProductDescription,
                            base.TargetObject.ProductQuantity, base.TargetObject.ProductPrice, base.TargetObject.ProductExpiryDate,
                            base.TargetObject.ProductRegNum, base.TargetObject.ProductPartNum, base.TargetObject.ProductStorageLocation);
                        if (entities.Products.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.Products.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                        //Find this entry in the view that corresponds to the entry in the table and if it is found reload it, if not then not
                        ExtendedProductView pr_view = entities.ExtendedProductViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                        if (pr_view != null)
                        {
                            entities.Entry(pr_view).Reload();
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for products is done only by the administrators of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        protected override async Task<bool> deleteTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "Product has been deleted.";
                if (base.CurrentUser != null && base.CurrentUser.UserRole == 0)
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.DeleteProductByID(base.TargetObject.ID);
                        if (entities.Products.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.Products.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                        //Find this entry in the view that corresponds to the entry in the table and if it is found reload it, if not then not
                        ExtendedProductView pr_view = entities.ExtendedProductViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                        if (pr_view != null)
                        {
                            entities.Entry(pr_view).Reload();
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for products is done only by the administrators of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        //No custom task by default, if you want custom tasks inherit from this class

    }

    public class BulkProductImageOperation : BulkOperation<ProductImage>
    {
        static Entities entities;

        public BulkProductImageOperation() : base()
        {

        }

        public BulkProductImageOperation(BulkOperationType type, ref Entities ent, ProductImage target_image, bool is_silent) : base(type, target_image, is_silent)
        {
            entities = ent;
            base.OperationName = $"{type} operation on {base.TargetObject.GetType()} with ID: {base.TargetObject.ID}";
        }

        public override void UpdateName()
        {
            base.OperationName = $"{base.OperationType} operation on {base.TargetObject.GetType()} with ID: {base.TargetObject.ID}";
        }

        protected override async Task<bool> createTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "Product Image has been added.";
                if (base.CurrentUser != null && (base.CurrentUser.UserRole == 0 || base.CurrentUser.UserRole == 1))
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.AddProductImage(base.TargetObject.ProductID, base.TargetObject.ImageName, base.TargetObject.ImageData);
                        if (entities.ProductImages.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.ProductImages.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for product images is done only by the administrators and employees of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        protected override async Task<bool> updateTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "Product Image has been updated.";
                if (base.CurrentUser != null && (base.CurrentUser.UserRole == 0 || base.CurrentUser.UserRole == 1))
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.UpdateProductImageByID(base.TargetObject.ID, base.TargetObject.ProductID, base.TargetObject.ImageName, base.TargetObject.ImageData);
                        if (entities.ProductImages.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.ProductImages.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for product images is done only by the administrators and employees of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        protected override async Task<bool> deleteTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "Product Image has been deleted.";
                if (base.CurrentUser != null && (base.CurrentUser.UserRole == 0 || base.CurrentUser.UserRole == 1))
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.DeleteProductImageByID(base.TargetObject.ID);
                        if (entities.ProductImages.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.ProductImages.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for product images is done only by the administrators and employees of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        //No custom task by default, if you want custom tasks inherit from this class

    }

    public class BulkProductOrderOperation : BulkOperation<ProductOrder>
    {
        static Entities entities;
        bool add_total_price_override_on_create;

        public BulkProductOrderOperation() : base()
        {

        }

        public BulkProductOrderOperation(BulkOperationType type, ref Entities ent, ProductOrder target_order, bool add_total_price_override_on_create, bool is_silent) : base(type, target_order, is_silent)
        {
            entities = ent;
            base.OperationName = $"{type} operation on {base.TargetObject.GetType()} with ID: {base.TargetObject.ID}";
            this.add_total_price_override_on_create = add_total_price_override_on_create;
        }

        public override void UpdateName()
        {
            base.OperationName = $"{base.OperationType} operation on {base.TargetObject.GetType()} with ID: {base.TargetObject.ID}";
        }

        protected override async Task<bool> createTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "Product Order has been added.";
                if (base.CurrentUser != null && (base.CurrentUser.UserRole == 0 || base.CurrentUser.UserRole == 1))
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.AddProductOrder(base.TargetObject.ProductID, base.TargetObject.DesiredQuantity, base.TargetObject.OrderPrice,
                        base.TargetObject.ClientID, base.TargetObject.EmployeeID, base.TargetObject.OrderReason, add_total_price_override_on_create);
                        if (entities.ProductOrders.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.ProductOrders.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                        //get the view of the table where the table entry exists and if exist reload to ensure it has updated data
                        ExtendedProductOrdersView pro_view = entities.ExtendedProductOrdersViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                        if (pro_view != null)
                        {
                            entities.Entry(pro_view).Reload();
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for product orders is done only by the administrators and employees of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
                return result;
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
                return result;
            }
        }

        protected override async Task<bool> updateTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "Product Order has been updated.";
                if (base.CurrentUser != null && (base.CurrentUser.UserRole == 0 || base.CurrentUser.UserRole == 1))
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.UpdateProductOrderByID(base.TargetObject.ID, base.TargetObject.ProductID, base.TargetObject.DesiredQuantity, base.TargetObject.OrderPrice,
                        base.TargetObject.ClientID, base.TargetObject.EmployeeID, base.TargetObject.OrderStatus, base.TargetObject.OrderReason);
                        if (entities.ProductOrders.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.ProductOrders.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                        //get the view of the table where the table entry exists and if exist reload to ensure it has updated data
                        ExtendedProductOrdersView pro_view = entities.ExtendedProductOrdersViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                        if (pro_view != null)
                        {
                            entities.Entry(pro_view).Reload();
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for product orders is done only by the administrators and employees of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
                return result;
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
                return result;
            }
        }

        protected override async Task<bool> deleteTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "Product Order has been deleted.";
                if (base.CurrentUser != null && (base.CurrentUser.UserRole == 0 || base.CurrentUser.UserRole == 1))
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.DeleteProductOrderByID(base.TargetObject.ID);
                        if (entities.ProductOrders.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.ProductOrders.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                        //get the view of the table where the table entry exists and if exist reload to ensure it has updated data
                        ExtendedProductOrdersView pro_view = entities.ExtendedProductOrdersViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                        if (pro_view != null)
                        {
                            entities.Entry(pro_view).Reload();
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for product orders is done only by the administrators and employees of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
                return result;
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
                return result;
            }
        }

        //No custom task by default, if you want custom tasks inherit from this class

    }

    public class BulkOrderDeliveryOperation : BulkOperation<OrderDelivery>
    {
        static Entities entities;

        public BulkOrderDeliveryOperation() : base()
        {

        }

        public BulkOrderDeliveryOperation(BulkOperationType type, ref Entities ent, OrderDelivery target_delivery, bool is_silent) : base(type, target_delivery, is_silent)
        {
            entities = ent;
            base.OperationName = $"{type} operation on {base.TargetObject.GetType()} with ID: {base.TargetObject.ID}";
        }

        public override void UpdateName()
        {
            base.OperationName = $"{base.OperationType} operation on {base.TargetObject.GetType()} with ID: {base.TargetObject.ID}";
        }

        protected override async Task<bool> createTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "Order Delivery has been added.";
                if (base.CurrentUser != null && (base.CurrentUser.UserRole == 0 || base.CurrentUser.UserRole == 1))
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.AddOrderDelivery(base.TargetObject.OrderID, base.TargetObject.DeliveryServiceID, base.TargetObject.PaymentMethodID,
                            base.TargetObject.CargoID, base.TargetObject.DeliveryReason);
                        if (entities.OrderDeliveries.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.OrderDeliveries.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                        //whenever you do an operation on something check if it exist in the database views and reload it in the model
                        //if it exist in the views and/or the tables
                        ExtendedOrderDeliveriesView od_view = entities.ExtendedOrderDeliveriesViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                        if (od_view != null)
                        {
                            entities.Entry(od_view).Reload();
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for order deliveries is done only by the administrators and employees of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        protected override async Task<bool> updateTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "Order Delivery has been updated.";
                if (base.CurrentUser != null && (base.CurrentUser.UserRole == 0 || base.CurrentUser.UserRole == 1))
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.UpdateOrderDeliveryByID(base.TargetObject.ID, base.TargetObject.OrderID, base.TargetObject.DeliveryServiceID, base.TargetObject.PaymentMethodID,
                            base.TargetObject.CargoID, base.TargetObject.DeliveryStatus, base.TargetObject.DeliveryReason);
                        if (entities.OrderDeliveries.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.OrderDeliveries.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                        //whenever you do an operation on something check if it exist in the database views and reload it in the model
                        //if it exist in the views and/or the tables
                        ExtendedOrderDeliveriesView od_view = entities.ExtendedOrderDeliveriesViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                        if (od_view != null)
                        {
                            entities.Entry(od_view).Reload();
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for order deliveries is done only by the administrators and employees of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        protected override async Task<bool> deleteTask()
        {
            bool result = false;
            try
            {
                result = true;
                base.SuccessMessage = "Order Delivery has been deleted.";
                if (base.CurrentUser != null && (base.CurrentUser.UserRole == 0 || base.CurrentUser.UserRole == 1))
                {
                    if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        entities.DeleteOrderDeliveryByID(base.TargetObject.ID);
                        if (entities.OrderDeliveries.Where(x => x.ID == TargetObject.ID).FirstOrDefault() != null)
                        {
                            entities.Entry(entities.OrderDeliveries.Where(x => x.ID == TargetObject.ID).FirstOrDefault()).Reload();
                        }
                        //whenever you do an operation on something check if it exist in the database views and reload it in the model
                        //if it exist in the views and/or the tables
                        ExtendedOrderDeliveriesView od_view = entities.ExtendedOrderDeliveriesViews.Where(x => x.ID == TargetObject.ID).FirstOrDefault();
                        if (od_view != null)
                        {
                            entities.Entry(od_view).Reload();
                        }
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("An access exception occured and this operation cannot be executed.", new Exception("Executing bulk operations for order deliveries is done only by the administrators and employees of this system.."));
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                base.ErrorMessage = ex.Message + "\n";
                base.ErrorCode = ex.HResult;
                base.StackTrace = ex.StackTrace + "\n";
                if (ex.InnerException != null)
                {
                    base.InnerErrorCode = ex.InnerException.HResult;
                    base.ErrorMessage += "Inner exception details:\n" + ex.InnerException.Message + "\n";
                    base.StackTrace += ex.InnerException.StackTrace + "\n";
                }
                result = false;
            }
            return result;
        }

        //No custom task by default, if you want custom tasks inherit from this class

    }

    public class BulkOperationEventArgs<T> : EventArgs 
    {
        public ObservableCollection<BulkOperation<T>> OperationsList = new ObservableCollection<BulkOperation<T>>();
        public int CompletedOperations = 0;
        public int FailedOperations = 0;
        public string Result = "";
        public string OperationLog = "";
        public Entities Entities = new Entities();
    }

    public class BulkOperationManager <T> :IDisposable//this will be the class that will be exposed
    {
        ObservableCollection<BulkOperation<T>> bulk_operations;
        static Entities entities;
        static User current_user;
        int completed_operations = 0;
        int failed_operations = 0;
        string result = "";
        string operation_log = "";
        public EventHandler<BulkOperationEventArgs<T>> BulkOperationsExecuted;
        public EventHandler<BulkOperationEventArgs<T>> BulkOperationAdded;
        public EventHandler<BulkOperationEventArgs<T>> BulkOperationRemoved;
        public EventHandler<BulkOperationEventArgs<T>> BulkOperationUpdated;
        public  Entities Entities { get { return entities; } }
        public User CurrentUser {  get { return current_user; } }
        public ObservableCollection<BulkOperation<T>> BulkOperations { get { return bulk_operations; } }
        public int CompletedOperations { get { return completed_operations; } }
        public int FailedOperations { get { return failed_operations; } }
        public string Result { get { return result; } }
        public string OperationLog { get { return operation_log; } }

        public BulkOperationManager() //default constructor, we won't use it
        {
            entities = new Entities();
            current_user = new User();
            bulk_operations = new ObservableCollection<BulkOperation<T>>();
            completed_operations = 0;
            failed_operations = 0;
            result = "";
            operation_log = "";
        }

        public BulkOperationManager(ref Entities ext_entities)
        {
            entities = ext_entities;
            current_user = new User();
            bulk_operations = new ObservableCollection<BulkOperation<T>>();
            completed_operations = 0;
            failed_operations = 0;
            result = "";
            operation_log = "";
        }
        public BulkOperationManager(ref Entities ext_entities, ref User working_user)
        {
            entities = ext_entities;
            current_user = working_user;
            bulk_operations = new  ObservableCollection<BulkOperation<T>> ();
            completed_operations = 0;
            failed_operations = 0;
            result = "";
            operation_log = "";
        }
        public BulkOperationManager(ref Entities ext_entities,ref User working_user, ref ObservableCollection<BulkOperation<T>> operations)
        {
            entities = ext_entities;
            current_user = working_user;
            if (operations != null)
            {
                bulk_operations = operations;
            }
            else
            {
                bulk_operations = new ObservableCollection<BulkOperation<T>>();
            }
            completed_operations = 0;
            failed_operations = 0;
            result = "";
            operation_log = "";
        }

        public async void ExecuteOperations()
        {
            DateTime startTime;
            DateTime endTime;
            TimeSpan deltaTime;
            startTime = DateTime.Now;
            try
            {
                if (bulk_operations != null && bulk_operations.Count > 0)
                {
                    operation_log = $"Operations started executing at: {startTime.ToShortTimeString()}\n";
                    foreach (BulkOperation<T> bulk_operation in bulk_operations)
                    {
                        bool result = await bulk_operation.Execute();
                        operation_log += $"Executing operation: {bulk_operation.OperationName}\n";
                        if (result == true)
                        {
                            completed_operations++;
                            operation_log += $"Operation successful.Output: {bulk_operation.SuccessMessage}\n";
                        }
                        else
                        {
                            failed_operations++;
                            operation_log += $"Operation failed. Here are details:\nError Code:{bulk_operation.ErrorCode}\n" +
                                $"ErrorMessage:{bulk_operation.ErrorMessage}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}: {bulk_operation.StackTrace}\n";
                        }
                        bulk_operation.Dispose();
                    }
                }
                for(int i = 0; i<bulk_operations.Count; i++)
                {
                    bulk_operations[i] = null;
                }
                endTime = DateTime.Now;
                deltaTime = endTime - startTime;
                operation_log += $"Operations finished. Time finished:{endTime.ToShortTimeString()}";
                bulk_operations.Clear();
                result = $"Operations Results: Completed Operations: {completed_operations} Failed Operations: {failed_operations} Execution Time: {deltaTime}";
                BulkOperationEventArgs<T> ev_args = new BulkOperationEventArgs<T>();
                ev_args.OperationsList = bulk_operations;
                ev_args.CompletedOperations = completed_operations;
                ev_args.FailedOperations = failed_operations;
                ev_args.Result = result;
                ev_args.OperationLog = operation_log;
                ev_args.Entities = entities;
                InvokeBulkOperationsExecutedEvent(this, ev_args);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ex.InnerException != null)
                {
                    MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }  
            }
        }

        public void AddOperation(BulkOperation<T> bulk_operation)
        {
            try
            {
                if (bulk_operation != null && !bulk_operations.Contains(bulk_operation))
                { // don't allow any operation of type that is not of the type of the manager to be added
                    bulk_operation.CurrentUser = this.CurrentUser;
                    bulk_operations.Add(bulk_operation);
                }
                //let's test the memory addresses of the items
                BulkOperationEventArgs<T> ev_args = new BulkOperationEventArgs<T>();
                ev_args.OperationsList = bulk_operations;
                ev_args.CompletedOperations = completed_operations;
                ev_args.FailedOperations = failed_operations;
                ev_args.Result = result;
                ev_args.Entities = entities;
                InvokeBulkOperationAddedEvent(this, ev_args);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ex.InnerException != null)
                {
                    MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void RemoveOperation(BulkOperation<T> bulk_operation)
        {   //Look what I did on the add opration method, same is here but for removing bulk operation
            try
            {
                if (bulk_operation != null && bulk_operations.Contains(bulk_operation))
                {
                    int operation_index = bulk_operations.IndexOf(bulk_operation);
                    bulk_operations[operation_index].Dispose();
                    bulk_operations.RemoveAt(operation_index);
                }
                BulkOperationEventArgs<T> ev_args = new BulkOperationEventArgs<T>();
                ev_args.OperationsList = bulk_operations;
                ev_args.CompletedOperations = completed_operations;
                ev_args.FailedOperations = failed_operations;
                ev_args.Result = result;
                ev_args.OperationLog = operation_log;
                ev_args.Entities = entities;
                InvokeBulkOperationRemovedEvent(this, ev_args);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ex.InnerException != null)
                {
                    MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void UpdateOperation(BulkOperation<T> bulk_operation)
        {   //Look what I did on the add opration method and remove operation, same is here but for updating bulk operation
            try
            {
                if (bulk_operation != null && bulk_operations.Contains(bulk_operation))
                {
                    int operation_index = bulk_operations.IndexOf(bulk_operation);
                    Type current_operation_type = bulk_operations[operation_index].GetType();
                    Type template_operation_type = bulk_operation.GetType();
                    BulkOperation<T> current_operation_for_change = bulk_operations[operation_index];
                    if (template_operation_type.IsAssignableFrom(current_operation_type))
                    {
                        current_operation_for_change = (BulkOperation<T>)Activator.CreateInstance(current_operation_type);
                        foreach (var property in current_operation_type.GetProperties())
                        {
                            var current_operation_property = property.GetValue(current_operation_for_change, null);
                            var template_operation_property = property.GetValue(bulk_operation, null);
                            if ( current_operation_property != null && current_operation_property.Equals(current_operation_for_change.TargetObject)) //if it is the target object update the target object using the function
                            {
                                current_operation_for_change.UpdateTargetObject(bulk_operation.TargetObject);
                            }
                            else
                            {
                                property.SetValue(current_operation_for_change, template_operation_property, null); //else update it using the reflection
                            }
                        }
                        current_operation_for_change.CurrentUser = this.CurrentUser;
                        current_operation_for_change.UpdateName();
                        bulk_operations[operation_index] = current_operation_for_change;
                    }
                }
                BulkOperationEventArgs<T> ev_args = new BulkOperationEventArgs<T>();
                ev_args.OperationsList = bulk_operations;
                ev_args.CompletedOperations = completed_operations;
                ev_args.FailedOperations = failed_operations;
                ev_args.Result = result;
                ev_args.OperationLog = operation_log;
                ev_args.Entities = entities;
                InvokeBulkOperationUpdatedEvent(this, ev_args);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ex.InnerException != null)
                {
                    MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void UpdateAllOperations(BulkOperation<T> bulk_operation)
        {   //This safely update everything according to the updating operation method
            try
            {
                if (bulk_operation != null)
                {
                    for (int i = 0; i < bulk_operations.Count; i++)
                    {
                        Type current_operation_type = bulk_operations[i].GetType();
                        Type template_operation_type = bulk_operation.GetType();
                        BulkOperation<T> current_operation_for_change = bulk_operations[i];
                        if (template_operation_type.IsAssignableFrom(current_operation_type))
                        {
                            current_operation_for_change = (BulkOperation<T>)Activator.CreateInstance(current_operation_type);
                            foreach (var property in current_operation_type.GetProperties())
                            {
                                var current_operation_property = property.GetValue(current_operation_for_change, null);
                                var template_operation_property = property.GetValue(bulk_operation, null);
                                if (current_operation_property != null && current_operation_property.Equals(current_operation_for_change.TargetObject)) //if it is the target object update the target object using the function
                                {
                                    current_operation_for_change.UpdateTargetObject(bulk_operation.TargetObject);
                                }
                                else
                                {
                                    property.SetValue(current_operation_for_change, template_operation_property, null); //else update it using the reflection
                                }
                            }
                            current_operation_for_change.CurrentUser = this.CurrentUser;
                            current_operation_for_change.UpdateName();
                            bulk_operations[i] = current_operation_for_change;
                        }
                    }
                }
                BulkOperationEventArgs<T> ev_args = new BulkOperationEventArgs<T>();
                ev_args.OperationsList = bulk_operations;
                ev_args.CompletedOperations = completed_operations;
                ev_args.FailedOperations = failed_operations;
                ev_args.Result = result;
                ev_args.OperationLog = operation_log;
                ev_args.Entities = entities;
                InvokeBulkOperationUpdatedEvent(this, ev_args);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ex.InnerException != null)
                {
                    MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void InvokeBulkOperationsExecutedEvent(object sender, BulkOperationEventArgs<T> e)
        {
            if(BulkOperationsExecuted != null)
            {
                BulkOperationsExecuted(this,e);
            }
        }

        private void InvokeBulkOperationAddedEvent(object sender, BulkOperationEventArgs<T> e)
        {
            if (BulkOperationAdded != null)
            {
                BulkOperationAdded(this, e);
            }
        }

        private void InvokeBulkOperationRemovedEvent(object sender, BulkOperationEventArgs<T> e)
        {
            if (BulkOperationRemoved != null)
            {
                BulkOperationRemoved(this, e);
            }
        }

        private void InvokeBulkOperationUpdatedEvent(object sender, BulkOperationEventArgs<T> e)
        {
            if (BulkOperationUpdated != null)
            {
                BulkOperationUpdated(this, e);
            }
        }

        public void Dispose()
        {
            if(operation_log != null)
            {
                operation_log = null;
            }
            if(result != null)
            {
                result = null;
            }
            completed_operations = -1;
            failed_operations = -1;
            if(current_user != null)
            {
                current_user = null;
            }
            if(BulkOperationAdded != null)
            {
                BulkOperationAdded = null;
            }
            if(BulkOperationRemoved != null)
            {
                BulkOperationRemoved = null;
            }
            if(BulkOperationUpdated != null)
            {
                BulkOperationUpdated = null;
            }
            if (BulkOperationsExecuted != null)
            {
                BulkOperationsExecuted = null;
            }
            if(entities!=null)
            {
                entities = null;
            }
            if(bulk_operations !=null)
            {
                foreach(var operation in bulk_operations)
                {
                    if(operation.GetType().GetInterfaces().Contains(typeof(IDisposable)))
                    {
                        operation.Dispose();
                    }
                }
                bulk_operations.Clear();
                bulk_operations = null;
            }
        }
    }
}
