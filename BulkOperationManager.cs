using Microsoft.ReportingServices.Diagnostics.Utilities;
using Microsoft.ReportingServices.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
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

    public class BulkOperation<T>//This is the class to derive all bulk operations from and its tasks will be overriden
    {
        BulkOperationType type;
        T target_object;
        string operation_name = "";
        string success_message = "";
        string error_message = "";
        string stack_trace = "";
        int error_code = -1;
        int inner_error_code = -1;
        bool is_silent = true;


        public T TargetObject { get { return target_object; } set { target_object = value; }  }
        public BulkOperationType OperationType { get { return type; } set { type = value; } }
        public string OperationName { get { return operation_name; } set { operation_name = value; } }
        public string SuccessMessage { get { return success_message; } set { success_message = value; } }
        public string ErrorMessage { get { return error_message; } set { error_message = value; } }
        public string StackTrace { get { return stack_trace; } set { stack_trace = value; } }
        public bool IsSilent { get { return is_silent; } set { is_silent = value; } }
        public int ErrorCode {  get { return error_code; } set { error_code = value; } }
        public int InnerErrorCode { get { return inner_error_code; } set { inner_error_code = value; } }
        public BulkOperation(BulkOperationType optype,T obj, bool is_silent)
        {
            type = optype;
            if (obj != null && typeof(T) == obj.GetType())  
            {
                target_object = obj;
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
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    }

    public class BulkUserOperation : BulkOperation<User>
    {
        static Entities entities;

        public BulkUserOperation(BulkOperationType type,ref Entities ent, User target_user, bool is_silent) : base(type, target_user, is_silent)
        {
            entities = ent;
            base.OperationName = $"{type} operation on {base.TargetObject.GetType()} with ID: {base.TargetObject.ID}";
        }

        private PropertyChangedEventHandler OnTargetObjectChanged(EventArgs eventArgs)
        {
            throw new NotImplementedException();
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
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.AddUser(base.TargetObject.UserName, base.TargetObject.UserPassword, base.TargetObject.UserDisplayName, base.TargetObject.UserBirthDate, base.TargetObject.UserPhone,
                                     base.TargetObject.UserEmail, base.TargetObject.UserAddress, base.TargetObject.UserProfilePic, base.TargetObject.UserBalance, base.TargetObject.UserDiagnose,
                                     base.TargetObject.UserRole);
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}:::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.UpdateUserByID(base.TargetObject.ID, base.TargetObject.UserName, base.TargetObject.UserPassword, base.TargetObject.UserDisplayName, base.TargetObject.UserBirthDate, base.TargetObject.UserPhone,
                                     base.TargetObject.UserEmail, base.TargetObject.UserAddress, base.TargetObject.UserProfilePic, base.TargetObject.UserBalance, base.TargetObject.UserDiagnose,
                                     base.TargetObject.UserRole);
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.DeleteUserByID(base.TargetObject.ID);
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.AddBrand(base.TargetObject.BrandName);
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.UpdateBrandByID(base.TargetObject.ID, base.TargetObject.BrandName);
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.DeleteBrandByID(base.TargetObject.ID);
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.AddPaymentMethod(base.TargetObject.MethodName);
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.UpdatePaymentMethodByID(base.TargetObject.ID, base.TargetObject.MethodName);
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
                return result;
            }
            catch (Exception ex)
            {
                if (base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.DeletePaymentMethodByID(base.TargetObject.ID);
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.AddDeliveryService(base.TargetObject.ServiceName, base.TargetObject.ServicePrice);
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.UpdateDeliveryServiceByID(base.TargetObject.ID, base.TargetObject.ServiceName, base.TargetObject.ServicePrice);
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.DeleteDeliveryServiceByID(base.TargetObject.ID);
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public BulkProductOperation(BulkOperationType type, ref Entities ent, Product target_product, bool is_silent) : base(type, target_product, is_silent)
        {
            base.TargetObject = base.TargetObject;
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
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.AddProduct(base.TargetObject.ProductName,base.TargetObject.BrandID, base.TargetObject.ProductDescription,
                        base.TargetObject.ProductQuantity, base.TargetObject.ProductPrice, base.TargetObject.ProductExpiryDate,
                        base.TargetObject.ProductRegNum, base.TargetObject.ProductPartNum, base.TargetObject.ProductStorageLocation);
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.UpdateProductByID(base.TargetObject.ID,base.TargetObject.ProductName, base.TargetObject.BrandID, base.TargetObject.ProductDescription,
                        base.TargetObject.ProductQuantity, base.TargetObject.ProductPrice, base.TargetObject.ProductExpiryDate,
                        base.TargetObject.ProductRegNum, base.TargetObject.ProductPartNum, base.TargetObject.ProductStorageLocation);
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.DeleteProductByID(base.TargetObject.ID);
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.AddProductImage(base.TargetObject.ProductID,base.TargetObject.ImageName,base.TargetObject.ImageData);
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.UpdateProductImageByID(base.TargetObject.ID,base.TargetObject.ProductID, base.TargetObject.ImageName, base.TargetObject.ImageData);
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.DeleteProductImageByID(base.TargetObject.ID);
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.AddProductOrder(base.TargetObject.ProductID, base.TargetObject.DesiredQuantity, base.TargetObject.OrderPrice,
                    base.TargetObject.ClientID, base.TargetObject.EmployeeID, base.TargetObject.OrderReason, add_total_price_override_on_create);
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
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.UpdateProductOrderByID(base.TargetObject.ID,base.TargetObject.ProductID, base.TargetObject.DesiredQuantity, base.TargetObject.OrderPrice,
                    base.TargetObject.ClientID, base.TargetObject.EmployeeID, base.TargetObject.OrderStatus, base.TargetObject.OrderReason);
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
                return result;
            }
            catch (Exception ex)
            {
                if (base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.DeleteProductOrderByID(base.TargetObject.ID);
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
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.AddOrderDelivery(base.TargetObject.OrderID,base.TargetObject.DeliveryServiceID,base.TargetObject.PaymentMethodID,
                        base.TargetObject.CargoID,base.TargetObject.DeliveryReason);
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.UpdateOrderDeliveryByID(base.TargetObject.ID,base.TargetObject.OrderID, base.TargetObject.DeliveryServiceID, base.TargetObject.PaymentMethodID,
                        base.TargetObject.CargoID, base.TargetObject.DeliveryStatus , base.TargetObject.DeliveryReason);
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.DeleteOrderDeliveryByID(base.TargetObject.ID);
                }
                Debug.WriteLineIf(result, base.SuccessMessage);
            }
            catch (Exception ex)
            {
                if (!base.IsSilent)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner exception details:{ex.InnerException.Message}\nStackTrace:{ex.InnerException.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    public class BulkOperationManager <T>//this will be the class that will be exposed
    {
        ObservableCollection<BulkOperation<T>> bulk_operations;
        static Entities entities;
        int completed_operations = 0;
        int failed_operations = 0;
        string result = "";
        string operation_log = "";
        public EventHandler<BulkOperationEventArgs<T>> BulkOperationsExecuted;
        public EventHandler<BulkOperationEventArgs<T>> BulkOperationAdded;
        public EventHandler<BulkOperationEventArgs<T>> BulkOperationRemoved;
        public EventHandler<BulkOperationEventArgs<T>> BulkOperationUpdated;
        public  Entities Entities { get { return entities; } }
        public ObservableCollection<BulkOperation<T>> BulkOperations { get { return bulk_operations; } }
        public int CompletedOperations { get { return completed_operations; } }
        public int FailedOperations { get { return failed_operations; } }
        public string Result { get { return result; } }
        public string OperationLog { get { return operation_log; } }

        public BulkOperationManager(ref Entities ext_entities)
        {
            entities = ext_entities;
            bulk_operations = new  ObservableCollection<BulkOperation<T>> ();
            completed_operations = 0;
            failed_operations = 0;
            result = "";
            operation_log = "";
        }
        public BulkOperationManager(ref Entities ext_entities, ref ObservableCollection<BulkOperation<T>> operations)
        {
            entities = ext_entities;
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
            if(bulk_operations != null)
            {
                foreach(BulkOperation<T> bulk_operation in bulk_operations)
                {
                    if (bulk_operation.TargetObject.GetType() == typeof(T))
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
                                $"ErrorMessage:{bulk_operation.ErrorMessage}\nStackTrace: {bulk_operation.StackTrace}\n";
                        }
                    }
                }
            }
            bulk_operations.Clear();
            result = $"Operations Results:\nCompleted Operations: {completed_operations} Failed Operations: {failed_operations}";
            BulkOperationEventArgs<T> ev_args = new BulkOperationEventArgs<T>();
            ev_args.OperationsList = bulk_operations;
            ev_args.CompletedOperations = completed_operations;
            ev_args.FailedOperations = failed_operations;
            ev_args.Result = result;
            ev_args.OperationLog = operation_log;
            ev_args.Entities = entities;
            InvokeBulkOperationsExecutedEvent(this,ev_args);
        }

        public void AddOperation(BulkOperation<T> bulk_operation)
        {
            if (bulk_operation != null && bulk_operation.TargetObject.GetType() == typeof(T) && !bulk_operations.Contains(bulk_operation))
            { // don't allow any operation of type that is not of the type of the manager to be added
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

        public void RemoveOperation(BulkOperation<T> bulk_operation)
        {   //Look what I did on the add opration method, same is here but for removing bulk operation
            if(bulk_operation != null && bulk_operation.TargetObject.GetType() == typeof(T) && bulk_operations.Contains(bulk_operation))
            {
                int operation_index = bulk_operations.IndexOf(bulk_operation);
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

        public void UpdateOperation(BulkOperation<T> bulk_operation)
        {   //Look what I did on the add opration method and remove operation, same is here but for updating bulk operation
            if (bulk_operation != null && bulk_operation.TargetObject.GetType() == typeof(T) && bulk_operations.Contains(bulk_operation))
            {
                int operation_index = bulk_operations.IndexOf(bulk_operation);
                bulk_operations[operation_index] = bulk_operation;
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

        public void UpdateAllOperations(BulkOperation<T> bulk_operation)
        {   //This safely update everything according to the updating operation method
            if (bulk_operation != null && bulk_operation.TargetObject.GetType() == typeof(T))
            {
                for(int i = 0; i<bulk_operations.Count; i++)
                {
                    bulk_operations[i] = bulk_operation;
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
    }
}
