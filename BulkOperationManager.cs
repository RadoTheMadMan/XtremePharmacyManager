using Microsoft.ReportingServices.Diagnostics.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
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
    public class BulkOperation<T> //This is the class to derive all bulk operations from and its tasks will be overriden
    {
        static BulkOperationType type;
        static T target_object;
        static string operation_name = "";
        static string success_message = "";
        static string error_message = "";
        static string stack_trace = "";
        static int error_code = -1;
        static int inner_error_code = -1;
        bool is_silent = true;
        public T TargetObject { get { return target_object; } }
        public BulkOperationType OperationType { get { return type; } set { type = value; } }
        public string OperationName { get { return operation_name; } set { operation_name = value; } }
        public string SuccessMessage { get { return success_message; } set { success_message = value; } }
        public string ErrorMessage { get { return error_message; } set { error_message = value; } }
        public string StackTrace { get { return stack_trace; } set { stack_trace = value; } }
        public bool IsSilent { get { return is_silent; } }
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
                return result;
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
                result = false;
                return result;
            }
        }

        protected virtual async Task<bool> updateTask()
        {
            bool result = false;
            try
            {
                result = true;
                success_message = "Sample bulk update task executed successfully.";
                Debug.WriteLineIf(result, success_message);
                return result;
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
                return result;
            }
        }

        protected virtual async Task<bool> deleteTask()
        {
            bool result = false;
            try
            {
                result = true;
                success_message = "Sample bulk update task executed successfully.";
                Debug.WriteLineIf(result, success_message);
                return result;
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
                return result;
            }
        }

        protected virtual async Task<bool> customTask()
        {
            bool result = false;
            try
            {
                result = true;
                success_message = "Sample custom bulk task executed successfully.";
                Debug.WriteLineIf(result, success_message);
                return result;
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
                return result;
            }
        }

    }

    public class BulkUserOperation : BulkOperation<User>
    {
        static User current_user;
        static Entities entities;

        public BulkUserOperation(BulkOperationType type,ref Entities ent, User target_user, bool is_silent) : base(type, target_user, is_silent)
        {
            current_user = base.TargetObject;
            entities = ent;
            base.OperationName = $"{type} operation on {current_user.GetType()} with ID: {current_user.ID}";
        }

        protected override async Task<bool> createTask()
        {
            bool result = false;
            try
            {
                base.SuccessMessage = "User has been added.";
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.AddUser(current_user.UserName, current_user.UserPassword, current_user.UserDisplayName, current_user.UserBirthDate, current_user.UserPhone,
                                     current_user.UserEmail, current_user.UserAddress, current_user.UserProfilePic, current_user.UserBalance, current_user.UserDiagnose,
                                     current_user.UserRole);
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
                return result;
            }
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
                    entities.UpdateUserByID(current_user.ID,current_user.UserName, current_user.UserPassword, current_user.UserDisplayName, current_user.UserBirthDate, current_user.UserPhone,
                                     current_user.UserEmail, current_user.UserAddress, current_user.UserProfilePic, current_user.UserBalance, current_user.UserDiagnose,
                                     current_user.UserRole);
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
                base.SuccessMessage = "User has been deleted.";
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.DeleteUserByID(current_user.ID);
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

    public class BulkProductBrandOperation : BulkOperation<ProductBrand>
    {
        static ProductBrand current_brand;
        static Entities entities;

        public BulkProductBrandOperation(BulkOperationType type, ref Entities ent, ProductBrand target_brand, bool is_silent) : base(type, target_brand, is_silent)
        {
            current_brand = base.TargetObject;
            entities = ent;
            base.OperationName = $"{type} operation on {current_brand.GetType()} with ID: {current_brand.ID}";
        }

        protected override async Task<bool> createTask()
        {
            bool result = false;
            try
            {
                base.SuccessMessage = "Product Brand has been added.";
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.AddBrand(current_brand.BrandName);
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
                base.SuccessMessage = "Product Brand has been updated.";
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.UpdateBrandByID(current_brand.ID, current_brand.BrandName);
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
                base.SuccessMessage = "Product Brand has been deleted.";
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.DeleteBrandByID(current_brand.ID);
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

    public class BulkPaymentMethodOperation : BulkOperation<PaymentMethod>
    {
        static PaymentMethod current_payment_method;
        static Entities entities;

        public BulkPaymentMethodOperation(BulkOperationType type, ref Entities ent, PaymentMethod target_method, bool is_silent) : base(type, target_method, is_silent)
        {
            current_payment_method = base.TargetObject;
            entities = ent;
            base.OperationName = $"{type} operation on {current_payment_method.GetType()} with ID: {current_payment_method.ID}";
        }

        protected override async Task<bool> createTask()
        {
            bool result = false;
            try
            {
                base.SuccessMessage = "Payment Method has been added.";
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.AddPaymentMethod(current_payment_method.MethodName);
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
                base.SuccessMessage = "Payment Method has been updated.";
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.UpdatePaymentMethodByID(current_payment_method.ID, current_payment_method.MethodName);
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
                base.SuccessMessage = "Payment Method has been deleted.";
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.DeletePaymentMethodByID(current_payment_method.ID);
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

    public class BulkDeliveryServiceOperation : BulkOperation<DeliveryService>
    {
        static DeliveryService current_service;
        static Entities entities;

        public BulkDeliveryServiceOperation(BulkOperationType type, ref Entities ent, DeliveryService target_service, bool is_silent) : base(type, target_service, is_silent)
        {
            current_service = base.TargetObject;
            entities = ent;
            base.OperationName = $"{type} operation on {current_service.GetType()} with ID: {current_service.ID}";
        }

        protected override async Task<bool> createTask()
        {
            bool result = false;
            try
            {
                base.SuccessMessage = "Delivery Service has been added.";
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.AddDeliveryService(current_service.ServiceName, current_service.ServicePrice);
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
                base.SuccessMessage = "Delivery Service has been updated.";
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.UpdateDeliveryServiceByID(current_service.ID, current_service.ServiceName, current_service.ServicePrice);
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
                base.SuccessMessage = "Delivery Service has been deleted.";
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.DeleteDeliveryServiceByID(current_service.ID);
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

    public class BulkProductOperation : BulkOperation<Product>
    {
        static Product current_product;
        static Entities entities;

        public BulkProductOperation(BulkOperationType type, ref Entities ent, Product target_product, bool is_silent) : base(type, target_product, is_silent)
        {
            current_product = base.TargetObject;
            entities = ent;
            base.OperationName = $"{type} operation on {current_product.GetType()} with ID: {current_product.ID}";
        }

        protected override async Task<bool> createTask()
        {
            bool result = false;
            try
            {
                base.SuccessMessage = "Product has been added.";
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.AddProduct(current_product.ProductName,current_product.BrandID, current_product.ProductDescription,
                        current_product.ProductQuantity, current_product.ProductPrice, current_product.ProductExpiryDate,
                        current_product.ProductRegNum, current_product.ProductPartNum, current_product.ProductStorageLocation);
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
                base.SuccessMessage = "Product has been updated.";
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.UpdateProductByID(current_product.ID,current_product.ProductName, current_product.BrandID, current_product.ProductDescription,
                        current_product.ProductQuantity, current_product.ProductPrice, current_product.ProductExpiryDate,
                        current_product.ProductRegNum, current_product.ProductPartNum, current_product.ProductStorageLocation);
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
                base.SuccessMessage = "Product has been deleted.";
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.DeleteProductByID(current_product.ID);
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

    public class BulkProductImageOperation : BulkOperation<ProductImage>
    {
        static ProductImage current_image;
        static Entities entities;

        public BulkProductImageOperation(BulkOperationType type, ref Entities ent, ProductImage target_image, bool is_silent) : base(type, target_image, is_silent)
        {
            current_image = base.TargetObject;
            entities = ent;
            base.OperationName = $"{type} operation on {current_image.GetType()} with ID: {current_image.ID}";
        }

        protected override async Task<bool> createTask()
        {
            bool result = false;
            try
            {
                base.SuccessMessage = "Product Image has been added.";
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.AddProductImage(current_image.ProductID,current_image.ImageName,current_image.ImageData);
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
                base.SuccessMessage = "Product Image has been updated.";
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.UpdateProductImageByID(current_image.ID,current_image.ProductID, current_image.ImageName, current_image.ImageData);
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
                base.SuccessMessage = "Product Image has been deleted.";
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.DeleteProductImageByID(current_image.ID);
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

    public class BulkProductOrderOperation : BulkOperation<ProductOrder>
    {
        static ProductOrder current_order;
        static Entities entities;
        bool add_total_price_override_on_create;

        public BulkProductOrderOperation(BulkOperationType type, ref Entities ent, ProductOrder target_order, bool add_total_price_override_on_create, bool is_silent) : base(type, target_order, is_silent)
        {
            current_order = base.TargetObject;
            entities = ent;
            base.OperationName = $"{type} operation on {current_order.GetType()} with ID: {current_order.ID}";
            this.add_total_price_override_on_create = add_total_price_override_on_create;
        }

        protected override async Task<bool> createTask()
        {
            bool result = false;
            try
            {
                base.SuccessMessage = "Product Order has been added.";
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.AddProductOrder(current_order.ProductID, current_order.DesiredQuantity, current_order.OrderPrice,
                    current_order.ClientID, current_order.EmployeeID, current_order.OrderReason, add_total_price_override_on_create);
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
                    entities.UpdateProductOrderByID(current_order.ID,current_order.ProductID, current_order.DesiredQuantity, current_order.OrderPrice,
                    current_order.ClientID, current_order.EmployeeID, current_order.OrderStatus, current_order.OrderReason);
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
                    entities.DeleteProductOrderByID(current_order.ID);
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
        static OrderDelivery current_delivery;
        static Entities entities;

        public BulkOrderDeliveryOperation(BulkOperationType type, ref Entities ent, OrderDelivery target_delivery, bool is_silent) : base(type, target_delivery, is_silent)
        {
            current_delivery = base.TargetObject;
            entities = ent;
            base.OperationName = $"{type} operation on {current_delivery.GetType()} with ID: {current_delivery.ID}";
        }

        protected override async Task<bool> createTask()
        {
            bool result = false;
            try
            {
                base.SuccessMessage = "Order Delivery has been added.";
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.AddOrderDelivery(current_delivery.OrderID,current_delivery.DeliveryServiceID,current_delivery.PaymentMethodID,
                        current_delivery.CargoID,current_delivery.DeliveryReason);
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
                base.SuccessMessage = "Order Delivery has been updated.";
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.UpdateOrderDeliveryByID(current_delivery.ID,current_delivery.OrderID, current_delivery.DeliveryServiceID, current_delivery.PaymentMethodID,
                        current_delivery.CargoID, current_delivery.DeliveryStatus , current_delivery.DeliveryReason);
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
                base.SuccessMessage = "User has been deleted.";
                if (entities != null && entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    entities.DeleteOrderDeliveryByID(current_delivery.ID);
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

    public class BulkOperationEventArgs<T> : EventArgs 
    {
        public ObservableCollection<BulkOperation<T>> OperationsList = new ObservableCollection<BulkOperation<T>>();
        public int CompletedOperations = 0;
        public int FailedOperations = 0;
        public string Result = "";
        public Entities Entities = new Entities();
    }

    public class BulkOperationManager <T>//this will be the class that will be exposed
    {
        static T target_object;
        List<BulkOperation<T>> bulk_operations;
        static Entities entities;
        static int completed_operations = 0;
        static int failed_operations = 0;
        static string result = "";
        public EventHandler<BulkOperationEventArgs<T>> BulkOperationsExecuted;
        public EventHandler<BulkOperationEventArgs<T>> BulkOperationAdded;
        public EventHandler<BulkOperationEventArgs<T>> BulkOperationRemoved;
        public EventHandler<BulkOperationEventArgs<T>> BulkOperationUpdated;
        public Entities Entities { get { return entities; } }
        public List<BulkOperation<T>> BulkOperations { get { return bulk_operations; } }
        public int CompletedOperations { get { return completed_operations; } }
        public int FailedOperations { get { return failed_operations; } }
        public string Result { get { return result; } }

        public BulkOperationManager(ref Entities ext_entities)
        {
            entities = ext_entities;
            bulk_operations = new  List<BulkOperation<T>> ();
            completed_operations = 0;
            failed_operations = 0;
            result = "";
        }
        public BulkOperationManager(ref Entities ext_entities, ref List<BulkOperation<T>> operations)
        {
            entities = ext_entities;
            if (operations != null)
            {
                bulk_operations = operations;
            }
            else
            {
                bulk_operations = new List<BulkOperation<T>>();
            }
            completed_operations = 0;
            failed_operations = 0;
            result = "";
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
                        if (result == true)
                        {
                            completed_operations++;
                        }
                        else
                        {
                            failed_operations++;
                        }
                    }
                }
            }
            bulk_operations.Clear();
            result = $"Operations Result:\nCompleted Operations: {completed_operations} Failed Operations: {failed_operations}";
            BulkOperationEventArgs<T> ev_args = new BulkOperationEventArgs<T>();
            ev_args.OperationsList = bulk_operations;
            ev_args.CompletedOperations = completed_operations;
            ev_args.FailedOperations = failed_operations;
            ev_args.Result = result;
            ev_args.Entities = entities;
            InvokeBulkOperationsExecutedEvent(this,ev_args);
        }

        public void AddOperation(BulkOperation<T> bulk_operation)
        {
            if (bulk_operation != null && bulk_operation.TargetObject.GetType() == typeof(T))
            { // don't allow any operation of type that is not of the type of the manager to be added
                bulk_operations.Insert(bulk_operations.Count,bulk_operation);   
            }
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
