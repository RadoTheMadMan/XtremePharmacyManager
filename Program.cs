using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using XtremePharmacyManager.DataEntities;
using XtremePharmacyManager.Properties;

namespace XtremePharmacyManager
{
    ///<summary>
    ///here will be all resources and settings we need to get at startup except the
    ///Entity framework metadata path which  is always looked in the DataEntities folder
    ///as seen in obj/WhateverConfigurationYouCompileFor/edmxResourcesToEmbed
    ///it basically sets the directory the same as the project directory, in
    ///my case the DataEntities/entitymodelresourcesfile.csdl and etc
    ///</summary>
    public class GLOBAL_RESOURCES 
    {
        private static string dOMAIN_ADDRESS = "";
        private static string dB_NAME = "";
        private static string dB_USER = "";
        private static string dB_PASSWORD = "";
        private static string cOMPANY_NAME = "";
        private static string cURRENT_CULTURE = "";
        private static string rEPORT_DIRECTORY = "";
        private static string sAVED_LOGINS_DIRECTORY = "";
        private static string eMPLOYEE_REPORT_NAME = "";
        private static string cLIENT_REPORT_NAME = "";
        private static string pRODUCT_BRAND_REPORT_NAME = "";
        private static string pRODUCT_VENDOR_REPORT_NAME = "";
        private static string pAYMENT_METHOD_REPORT_NAME = "";
        private static string dELIVERY_SERVICE_REPORT_NAME = "";
        private static string pRODUCT_REPORT_NAME = "";
        private static string pRODUCT_ORDER_REPORT_NAME = "";
        private static string pRODUCT_ORDER_INVOICE_REPORT_NAME = "";
        private static string oRDER_DELIVERY_REPORT_NAME = "";
        private static string oRDER_DELIVERY_INVOICE_REPORT_NAME = "";
        private static string cRITICAL_ERROR_MESSAGE = "";
        private static string cRITICAL_ERROR_INNER_EXCEPTION_DETAILS = "";
        private static string sTACK_TRACE_MESSAGE = "";
        private static string cRITICAL_ERROR_TITLE = "";
        private static string cLOSE_PROMPT = "";
        private static string cLOSE_PROMPT_TITLE = "";
        private static string aPPLICATION_INSTANCE_ERROR_MESSAGE = "";
        private static string cONNECTION_SUCCESSFUL_MESSAGE = "";
        private static string cONNECTION_SUCCESSFUL_LOGIN_MESSAGE = "";
        private static string cONNECTION_FAILED_MESSAGE = "";
        private static string cONNECTION_FAILED_AFTER_RETRY_MESSAGE = "";
        private static string cONNECTION_FAILED_LOGIN_MESSAGE = "";
        private static string aUTHORISATION_ERROR_NO_LOGIN_MESSAGE = "";
        private static string aUTHORISATION_ERROR_CANCELLED_LOGIN_MESSAGE = "";
        private static string aUTHORISATION_ERROR_CLIENT_LOGIN_MESSAGE = "";
        private static string aUTHORISATION_ERROR_SYSADMIN_BREACH_MESSAGE = "";
        private static string aUTHORISATION_APPCONF_LOGIN_FOUND_MESSAGE = "";
        private static string aUTHORISATION_APPCONF_LOGIN_NOT_FOUND_MESSAGE = "";
        private static string aUTHORISATION_LOGIN_EMPTY_INPUT_MESSAGE = "";
        private static string aUTHORISATION_LOGIN_INVALID_INPUT_MESSAGE = "";
        private static string aUTHORISATION_ADD_LOGIN_INVALID_RESULTS_MESSAGE = "";
        private static string aUTHORISATION_LOGIN_NO_CONNECTION_MESSAGE = "";
        private static string aUTHORISATION_LOGIN_FILESYSTEM_LOAD_ERROR_MESSAGE = "";
        private static string aUTHORISATION_LOGIN_EMPLOYEE_NOTICE = "";
        private static string aUTHORISATION_LOGIN_ADMIN_NOTICE = "";
        private static string uSER_ACCESS_TITLE = "";
        private static string pRODUCT_MENU_ACCESS_ADMIN_NOTICE = "";
        private static string pRODUCT_MENU_ACCESS_EMPLOYEE_NOTICE = "";
        private static string uSER_MENU_ACCESS_ERROR_MESSAGE = "";
        private static string bRAND_MENU_ACCESS_ERROR_MESSAGE = "";
        private static string vENDOR_MENU_ACCESS_ERROR_MESSAGE = "";
        private static string pAYMENT_METHOD_MENU_ACCESS_ERROR_MESSAGE = "";
        private static string dELIVERY_SERVICE_MENU_ACCESS_ERROR_MESSAGE = "";
        private static string pRODUCT_MENU_ACCESS_ERROR_MESSAGE = "";
        private static string pRODUCT_ORDER_MENU_ACCESS_ERROR_MESSAGE = "";
        private static string oRDER_DELIVERY_MENU_ACCESS_ERROR_MESSAGE = "";
        private static string lOGS_MENU_ACCESS_ERROR_MESSAGE = "";
        private static string bULK_USER_MENU_ACCESS_ERROR_MESSAGE = "";
        private static string bULK_BRAND_MENU_ACCESS_ERROR_MESSAGE = "";
        private static string bULK_VENDOR_MENU_ACCESS_ERROR_MESSAGE = "";
        private static string bULK_PAYMENT_METHOD_MENU_ACCESS_ERROR_MESSAGE = "";
        private static string bULK_DELIVERY_SERVICE_MENU_ACCESS_ERROR_MESSAGE = "";
        private static string bULK_PRODUCT_MENU_ACCESS_ERROR_MESSAGE = "";
        private static string bULK_PRODUCT_IMAGE_MENU_ACCESS_ERROR_MESSAGE = "";
        private static string bULK_PRODUCT_ORDER_MENU_ACCESS_ERROR_MESSAGE = "";
        private static string bULK_ORDER_DELIVERY_MENU_ACCESS_ERROR_MESSAGE = "";
        private static string aCCOUNT_SETTINGS_ERROR_MESSAGE = "";
        private static string aCCOUNT_SETTINGS_INVALID_CREDENTIALS_ERROR_MESSAGE = "";
        private static string lANGUAGE_MANAGER_LANGUAGE_EXIST_ERROR_MESSAGE = "";
        private static string lANGUAGE_MANAGER_LANGUAGE_NONEXISTENT_ERROR_MESSAGE = "";
        private static string rEPORT_GENERATION_PERMISSION_ERROR = "";
        private static string rECORD_DELETION_WARNING = "";
        private static string uSER_EDIT_OPERATION_PERMISSION_ERROR = "";
        private static string uSER_DELETE_OPERATION_PERMISSION_ERROR = "";
        private static string vENDOR_EDIT_OPERATION_PERMISSION_ERROR = "";
        private static string vENDOR_DELETE_OPERATION_PERMISSION_ERROR = "";
        private static string pRODUCT_EDIT_OPERATION_PERMISSION_ERROR = "";
        private static string pRODUCT_DELETE_OPERATION_PERMISSION_ERROR = "";
        private static string pRODUCT_IMAGE_EDIT_OPERATION_PERMISSION_ERROR = "";
        private static string pRODUCT_IMAGE_DELETE_OPERATION_PERMISSION_ERROR = "";
        private static string pRODUCT_ORDER_TOTAL_PRICE_OVERRIDE_QUESTION = "";
        private static string bULK_PRODUCT_ORDER_TOTAL_PRICE_OVERRIDE_QUESTION = "";
        private static string pRODUCT_ORDER_DELETE_OPERATION_PERMISSION_ERROR = "";
        private static string pRODUCT_ORDER_EDIT_OPERATION_PERMISSION_ERROR = "";
        private static string pRODUCT_ORDER_INVOICE_GENERATION_QUESTION = "";
        private static string oRDER_DELIVERY_DELETE_OPERATION_PERMISSION_ERROR = "";
        private static string oRDER_DELIVERY_EDIT_OPERATION_PERMISSION_ERROR = "";
        private static string oRDER_DELIVERY_INVOICE_GENERATION_QUESTION = "";
        private static string bRAND_EDIT_OPERATION_PERMISSION_ERROR = "";
        private static string bRAND_DELETE_OPERATION_PERMISSION_ERROR = "";
        private static string pAYMENT_METHOD_EDIT_OPERATION_PERMISSION_ERROR = "";
        private static string pAYMENT_METHOD_DELETE_OPERATION_PERMISSION_ERROR = "";
        private static string dELIVERY_SERVICE_EDIT_OPERATION_PERMISSION_ERROR = "";
        private static string dELIVERY_SERVICE_DELETE_OPERATION_PERMISSION_ERROR = "";
        private static string iMAGE_BIN_CONVERTER_CONVERT_IMAGE_TITLE = "";
        private static string aPPLICATION_SETTINGS_CHANGES_NOTICE = "";
        private static string bULK_OPERATION_QUESTION = "";
        private static string bULK_OPERATION_OPERATION_ON_NAME = "";
        private static string bULK_OPERATION_OPERATION_ON_TARGET_ID_NAME = "";
        private static string bULK_OPERATION_UNAUTHORISED_ERROR_MESSAGE = "";
        private static string bULK_USER_OPERATION_UNAUTHORISED_ERROR_MESSAGE = "";
        private static string bULK_BRAND_OPERATION_UNAUTHORISED_ERROR_MESSAGE = "";
        private static string bULK_VENDOR_OPERATION_UNAUTHORISED_ERROR_MESSAGE = "";
        private static string bULK_PAYMENT_METHOD_OPERATION_UNAUTHORISED_ERROR_MESSAGE = "";
        private static string bULK_DELIVERY_SERVICE_OPERATION_UNAUTHORISED_ERROR_MESSAGE = "";
        private static string bULK_PRODUCT_OPERATION_UNAUTHORISED_ERROR_MESSAGE = "";
        private static string bULK_PRODUCT_IMAGE_OPERATION_UNAUTHORISED_ERROR_MESSAGE = "";
        private static string bULK_PRODUCT_ORDER_OPERATION_UNAUTHORISED_ERROR_MESSAGE = "";
        private static string bULK_ORDER_DELIVERY_OPERATION_UNAUTHORISED_ERROR_MESSAGE = "";
        private static string sAMPLE_BULK_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = "";
        private static string sAMPLE_BULK_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = "";
        private static string sAMPLE_BULK_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = "";
        private static string sAMPLE_BULK_OPERATION_CUSTOM_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_USER_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_USER_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_USER_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_BRAND_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_BRAND_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_BRAND_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_VENDOR_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_VENDOR_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_VENDOR_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_PAYMENT_METHOD_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_PAYMENT_METHOD_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_PAYMENT_METHOD_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_DELIVERY_SERVICE_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_DELIVERY_SERVICE_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_DELIVERY_SERVICE_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_PRODUCT_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_PRODUCT_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_PRODUCT_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_PRODUCT_IMAGE_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_PRODUCT_IMAGE_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_PRODUCT_IMAGE_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_PRODUCT_ORDER_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_PRODUCT_ORDER_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_PRODUCT_ORDER_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_ORDER_DELIVERY_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_ORDER_DELIVERY_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_ORDER_DELIVERY_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = "";
        private static string bULK_OPERATION_START_TIME_MESSAGE = "";
        private static string bULK_OPERATION_EXECUTING_MESSAGE = "";
        private static string bULK_OPERATION_SUCCESSFUL_MESSAGE = "";
        private static string bULK_OPERATION_FAILED_MESSAGE = "";
        private static string bULK_OPERATION_ERROR_CODE_MESSAGE = "";
        private static string bULK_OPERATION_ERROR_MESSAGE = "";
        private static string bULK_OPERATION_END_TIME_MESSAGE = "";
        private static string bULK_OPERATION_RESULTS_MESSAGE = "";
        private static string bULK_OPERATION_COMPLETED_COUNT_MESSAGE = "";
        private static string bULK_OPERATION_FAILED_COUNT_MESSAGE = "";
        private static string bULK_OPERATION_EXECUTION_TIME_MESSAGE = "";
        private static string bULK_USER_OPERATION_NO_PERMISSION_MESSAGE = "";
        private static string bULK_BRAND_OPERATION_NO_PERMISSION_MESSAGE = "";
        private static string bULK_VENDOR_OPERATION_NO_PERMISSION_MESSAGE = "";
        private static string bULK_PAYMENT_METHOD_OPERATION_NO_PERMISSION_MESSAGE = "";
        private static string bULK_DELIVERY_SERVICE_OPERATION_NO_PERMISSION_MESSAGE = "";
        private static string bULK_PRODUCT_OPERATION_NO_PERMISSION_MESSAGE = "";
        private static string bULK_PRODUCT_IMAGE_OPERATION_NO_PERMISSION_MESSAGE = "";
        private static string bULK_PRODUCT_ORDER_OPERATION_NO_PERMISSION_MESSAGE = "";
        private static string bULK_ORDER_DELIVERY_OPERATION_NO_PERMISSION_MESSAGE = "";
        private static string lBL_BULK_OPERATION_RESULTS_TEXT = "";
        private static string bULK_OPERATIONS_TITLE = "";
        private static string tEST_TITLE = "";
        private static string lOGIN_TITLE = "";
        private static string wARNING_TITLE = "";
        private static string cURRENT_HOST_TITLE = "";
        private static string cURRENT_OPERATOR_TITLE = "";
        private static string aCCOUNT_SETTINGS_TITLE = "";
        private static string aPPLICATION_SETTINGS_TITLE = "";
        private static string aCCOUNT_SETTINGS_PROFILE_PIC_SELECT_TITLE = "";
        private static string aPPLICATION_SETTINGS_LOGINS_FOLDER_SELECT_TITLE = "";
        private static string aPPLICATION_SETTINGS_REPORTS_FOLDER_SELECT_TITLE = "";
        private static string aBOUT_TITLE = "";
        private static string vERSION_TITLE = "";
        private static string aSSEMBLY_PRODUCT_NAME = "";
        private static string aSSEMBLY_TITLE = "";
        private static string nEW_ORDER_TITLE = "";
        private static string rEPORT_GENERATION_TITLE = "";
        private static string iMAGE_UPLOAD_FOR_OPERATION_TITLE = "";
        private static string uSERS_TITLE = "";
        private static string uSERS_TOOLTIP_TITLE = "";
        private static string rOLE_COL_TITLE = "";
        private static string lBL_ROLE_ADMIN = "";
        private static string lBL_ROLE_EMPLOYEE = "";
        private static string lBL_ROLE_CLIENT = "";
        private static string rOLE_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_ROLE_TITLE = "";
        private static string rEGISTER_DATE_COL_TITLE = "";
        private static string dIAGNOSE_COL_TITLE = "";
        private static string bALANCE_COL_TITLE = "";
        private static string pROFILE_PIC_COL_TITLE = "";
        private static string aDDRESS_COL_TITLE = "";
        private static string eMAIL_COL_TITLE = "";
        private static string pHONE_COL_TITLE = "";
        private static string bIRTH_DATE_COL_TITLE = "";
        private static string dISPLAY_NAME_COL_TITLE = "";
        private static string pASSWORD_COL_TITLE = "";
        private static string uSER_NAME_COL_TITLE = "";
        private static string uSER_ID_COL_TITLE = "";
        private static string hELP_TITLE = "";
        private static string uSER_NOTICE_TOOLTIP_TITLE = "";
        private static string lBL_USER_NOTICE_TITLE = "";
        private static string bTN_GENERATE_REPORT_TITLE = "";
        private static string bTN_GENERATE_REPORT_TOOLTIP_TITLE = "";
        private static string bALANCE_SEARCH_TOOLTIP_TITLE = "";
        private static string bTN_DELETE_TITLE = "";
        private static string bTN_DELETE_TOOLTIP_TITLE = "";
        private static string bTN_ADD_EDIT_TITLE = "";
        private static string bTN_ADD_EDIT_TOOLTIP_TITLE = "";
        private static string lBL_SEARCH_MODE_TITLE = "";
        private static string lBL_SEARCH_MODE_NONE = "";
        private static string lBL_SEARCH_MODE_SINGLE = "";
        private static string lBL_SEARCH_MODE_MULTIPLE = "";
        private static string lBL_SEARCH_MODE_ALL = "";
        private static string bTN_SEARCH_TITLE = "";
        private static string bTN_SEARCH_TOOLTIP_TITLE = "";
        private static string cB_SEARCH_MODE_TOOLTIP_TITLE = "";
        private static string uSER_REG_DATE_TO_SEARCH_TOOLTIP = "";
        private static string uSER_REG_DATE_FROM_SEARCH_TOOLTIP = "";
        private static string lBL_USER_REG_DATE_FROM_TITLE = "";
        private static string lBL_USER_REG_DATE_TO_TITLE = "";
        private static string dIAGNOSE_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_DIAGNOSE_TITLE = "";
        private static string lBL_BALANCE_TITLE = "";
        private static string aDDRESS_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_ADDRESS_TITLE = "";
        private static string eMAIL_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_EMAIL_TITLE = "";
        private static string pHONE_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_PHONE_TITLE = "";
        private static string uSER_B_DATE_TO_SEARCH_TOOLTIP = "";
        private static string uSER_B_DATE_FROM_SEARCH_TOOLTIP = "";
        private static string lBL_USER_B_DATE_FROM_TITLE = "";
        private static string lBL_USER_B_DATE_TO_TITLE = "";
        private static string dISPLAY_NAME_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_DISPLAY_NAME_TITLE = "";
        private static string pASSWORD_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_PASSWORD_TITLE = "";
        private static string uSERNAME_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_USERNAME_TITLE = "";
        private static string iD_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_ID_TITLE = "";
        private static string dGV_USERS_TOOLTIP_TITLE = "";
        private static string vENDOR_NAME_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_VENDOR_NAME_TITLE = "";
        private static string dGV_VENDORS_TOOLTIP_TITLE = "";
        private static string vENDOR_NAME_COL_TITLE = "";
        private static string vENDOR_ID_COL_TITLE = "";
        private static string vENDORS_TITLE = "";
        private static string vENDORS_TOOLTIP_TITLE = "";
        private static string lST_PRODUCT_IMAGES_TOOLTIP_TITLE = "";
        private static string pRODUCT_PRICE_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_PRICE_TITLE = "";
        private static string s_LOCATION_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_S_LOCATION_TITLE = "";
        private static string cB_SELECT_BRAND_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_QUANTITY_TITLE = "";
        private static string qUANTITY_SEARCH_TOOLTIP_TITLE = "";
        private static string pRODUCT_NOTICE_TOOLTIP_TITLE = "";
        private static string pRODUCT_ORDER_NOTICE_TOOLTIP_TITLE = "";
        private static string oRDER_DELIVERY_NOTICE_TOOLTIP_TITLE = "";
        private static string aCCOUNT_SETTINGS_NOTICE_TOOLTIP_TITLE = "";
        private static string lBL_PRODUCT_NOTICE_TITLE = "";
        private static string lBL_PRODUCT_IMAGE_NOTICE_TITLE = "";
        private static string lBL_VENDOR_TITLE = "";
        private static string cB_SELECT_VENDOR_SEARCH_TOOLTIP_TITLE = "";
        private static string pART_NUM_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_PART_NUM_TITLE = "";
        private static string rEG_NUM_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_REG_NUM_TITLE = "";
        private static string pRODUCT_EXP_DATE_FROM_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_PRODUCT_EXP_DATE_FROM_TITLE = "";
        private static string pRODUCT_EXP_DATE_TO_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_PRODUCT_EXP_DATE_TO_TITLE = "";
        private static string pRODUCT_DESCRIPTION_SEARCH_TOOLTIP_TITLE = "";
        private static string pRODUCT_NAME_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_PRODUCT_DESCRIPTION_TITLE = "";
        private static string lBL_BRAND_TITLE = "";
        private static string lBL_PRODUCT_NAME_TITLE = "";
        private static string dGV_PRODUCTS_TOOLTIP_TITLE = "";
        private static string lBL_IMAGES_TITLE = "";
        private static string bTN_SEARCH_PRODUCT_IMAGE_TITLE = "";
        private static string bTN_DELETE_PRODUCT_IMAGE_TITLE = "";
        private static string bTN_ADD_EDIT_PRODUCT_IMAGE_TITLE = "";
        private static string sELECTED_PRODUCT_IMAGE_TOOLTIP_TITLE = "";
        private static string lBL_IMAGE_NAME_TITLE = "";
        private static string lBL_IMAGE_ID_TITLE = "";
        private static string lBL_REFERENCED_ID_TITLE = "";
        private static string rEFERENCED_ID_SEARCH_TOOLTIP_TITLE = "";
        private static string iMAGE_NAME_SEARCH_TOOLTIP_TITLE = "";
        private static string pRODUCT_ID_COL_TITLE = "";
        private static string bRAND_COL_TITLE = "";
        private static string vENDOR_COL_TITLE = "";
        private static string pRODUCT_NAME_COL_TITLE = "";
        private static string pRODUCT_DESCRIPTION_COL_TITLE = "";
        private static string pRODUCT_QUANTITY_COL_TITLE = "";
        private static string pRODUCT_PRICE_COL_TITLE = "";
        private static string pRODUCT_EXP_DATE_COL_TITLE = "";
        private static string pRODUCT_REG_NUM_COL_TITLE = "";
        private static string pRODUCT_PART_NUM_COL_TITLE = "";
        private static string pRODUCT_S_LOCATION_COL_TITLE = "";
        private static string pRODUCTS_TITLE = "";
        private static string pRODUCTS_TOOLTIP_TITLE = "";
        private static string dGV_PRODUCT_ORDERS_TOOLTIP_TITLE = "";
        private static string pRICE_OVERRIDE_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_PRICE_OVERRIDE_TITLE = "";
        private static string oRDER_REASON_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_ORDER_REASON_TITLE = "";
        private static string pO_DATE_ADDED_TO_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_DATE_ADDED_TO_TITLE = "";
        private static string pO_DATE_ADDED_FROM_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_DATE_ADDED_FROM_TITLE = "";
        private static string lBL_EMPLOYEE_TITLE = "";
        private static string lBL_PRODUCT_TITLE = "";
        private static string eMPLOYEE_SEARCH_TOOLTIP_TITLE = "";
        private static string pRODUCT_SEARCH_TOOLTIP_TITLE = "";
        private static string cLIENT_SEARCH_TOOLTIP_TITLE = "";
        private static string pO_DATE_MODIFIED_FROM_SEARCH_TOOLTIP_TITLE = "";
        private static string pO_DATE_MODIFIED_TO_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_PRODUCT_ORDER_NOTICE_TITLE = "";
        private static string oRDER_STATUS_SEARCH_TOOLTIP_TITLE = "";
        private static string dESIRED_QUANTITY_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_ORDER_STATUS_TITLE = "";
        private static string lBL_ORDER_STATUS_PENDING = "";
        private static string lBL_STATUS_PREPAID = "";
        private static string lBL_STATUS_PAID_ON_DELIVERY = "";
        private static string lBL_STATUS_DIRECTLY_PAID = "";
        private static string lBL_STATUS_GENERATING_INVOICE = "";
        private static string lBL_STATUS_GENERATING_REPORT = "";
        private static string lBL_ORDER_STATUS_PROCESSING = "";
        private static string lBL_ORDER_STATUS_CANCELLED = "";
        private static string lBL_ORDER_STATUS_RETURNED = "";
        private static string lBL_ORDER_STATUS_COMPLETED = "";
        private static string lBL_DATE_MODIFIED_TO_TITLE = "";
        private static string lBL_DATE_MODIFIED_FROM_TITLE = "";
        private static string lBL_CLIENT_TITLE = "";
        private static string lBL_DESIRED_QUANTITY_TITLE = "";
        private static string oRDER_ID_COL_TITLE = "";
        private static string pRODUCT_COL_TITLE = "";
        private static string dESIRED_QUANTITY_COL_TITLE = "";
        private static string oRDER_PRICE_COL_TITLE = "";
        private static string eMPLOYEE_COL_TITLE = "";
        private static string cLIENT_COL_TITLE = "";
        private static string dATE_ADDED_COL_TITLE = "";
        private static string dATE_MODIFIED_COL_TITLE = "";
        private static string oRDER_STATUS_COL_TITLE = "";
        private static string oRDER_REASON_COL_TITLE = "";
        private static string pRODUCT_ORDERS_TITLE = "";
        private static string pRODUCT_ORDERS_TOOLTIP_TITLE = "";
        private static string bRAND_NAME_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_BRAND_NAME_TITLE = "";
        private static string dGV_PRODUCT_BRANDS_TOOLTIP_TITLE = "";
        private static string bRAND_NAME_COL_TITLE = "";
        private static string bRAND_ID_COL_TITLE = "";
        private static string pRODUCT_BRANDS_TITLE = "";
        private static string pRODUCT_BRANDS_TOOLTIP_TITLE = "";
        private static string mETHOD_NAME_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_METHOD_NAME_TITLE = "";
        private static string dGV_PAYMENT_METHODS_TOOLTIP_TITLE = "";
        private static string mETHOD_ID_COL_TITLE = "";
        private static string mETHOD_NAME_COL_TITLE = "";
        private static string pAYMENT_METHODS_TITLE = "";
        private static string pAYMENT_METHODS_TOOLTIP_TITLE = "";
        private static string dGV_ORDER_DELIVERIES_TOOLTIP_TITLE = "";
        private static string tOTAL_PRICE_SEARCH_TOOLTIP_TITLE = "";
        private static string cARGO_ID_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_CARGO_ID_TITLE = "";
        private static string lBL_DELIVERY_STATUS_TITLE = "";
        private static string lBL_DELIVERY_STATUS_PENDING = "";
        private static string lBL_DELIVERY_STATUS_ON_THE_MOVE = "";
        private static string lBL_DELIVERY_STATUS_CANCELLED = "";
        private static string lBL_DELIVERY_STATUS_RETURNED = "";
        private static string lBL_DELIVERY_STATUS_COMPLETED = "";
        private static string dELIVERY_STATUS_SEARCH_TOOLTIP_TITLE = "";
        private static string oRDER_DELIVERY_NOTICE_TITLE = "";
        private static string oD_DATE_MODIFIED_TO_SEARCH_TOOLTIP_TITLE = "";
        private static string oD_DATE_MODIFIED_FROM_SEARCH_TOOLTIP_TITLE = "";
        private static string pAYMENT_METHOD_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_PAYMENT_METHOD_TITLE = "";
        private static string pRODUCT_ORDER_SEARCH_TOOLTIP_TITLE = "";
        private static string dELIVERY_SERVICE_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_TOTAL_PRICE_TITLE = "";
        private static string dELIVERY_REASON_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_DELIVERY_REASON_TITLE = "";
        private static string oD_DATE_ADDED_TO_SEARCH_TOOLTIP_TITLE = "";
        private static string oD_DATE_ADDED_FROM_SEARCH_TOOLTIP_TITLE = "";
        private static string lBL_DELIVERY_SERVICE_TITLE = "";
        private static string lBL_PRODUCT_ORDER_TITLE = "";
        private static string dELIVERY_ID_COL_TITLE = "";
        private static string pRODUCT_ORDER_COL_TITLE = "";
        private static string tOTAL_PRICE_COL_TITLE = "";
        private static string dELIVERY_SERVICE_COL_TITLE = "";
        private static string pAYMENT_METHOD_COL_TITLE = "";
        private static string cARGO_ID_COL_TITLE = "";
        private static string dELIVERY_STATUS_COL_TITLE = "";
        private static string dELIVERY_REASON_COL_TITLE = "";
        private static string oRDER_DELIVERIES_TITLE = "";
        private static string oRDER_DELIVERIES_TOOLTIP_TITLE = "";
        public static string DELIVERY_PRICE_SEARCH_TOOLTIP_TITLE = "";
        public static string SERVICE_NAME_SEARCH_TOOLTIP_TITLE = "";
        public static string LBL_SERVICE_NAME_TITLE = "";
        public static string DGV_DELIVERY_SERVICES_TOOLTIP_TITLE = "";
        public static string SERVICE_ID_COL_TITLE = "";
        public static string SERVICE_NAME_COL_TITLE = "";
        public static string SERVICE_PRICE_COL_TITLE = "";
        public static string DELIVERY_SERVICES_TITLE = "";
        public static string DELIVERY_SERVICES_TOOLTIP_TITLE = "";
        public static GLOBAL_RESOURCES instance;
        public EventHandler<CultureInfo> CultureInfoChanged;

        public static string DOMAIN_ADDRESS { get => dOMAIN_ADDRESS; set => dOMAIN_ADDRESS = value; }
        public static string DB_NAME { get => dB_NAME; set => dB_NAME = value; }
        public static string DB_USER { get => dB_USER; set => dB_USER = value; }
        public static string DB_PASSWORD { get => dB_PASSWORD; set => dB_PASSWORD = value; }
        public static string COMPANY_NAME { get => cOMPANY_NAME; set => cOMPANY_NAME = value; }
        public static string CURRENT_CULTURE { get => cURRENT_CULTURE; set => cURRENT_CULTURE = value; }
        public static string REPORT_DIRECTORY { get => rEPORT_DIRECTORY; set => rEPORT_DIRECTORY = value; }
        public static string SAVED_LOGINS_DIRECTORY { get => sAVED_LOGINS_DIRECTORY; set => sAVED_LOGINS_DIRECTORY = value; }
        public static string EMPLOYEE_REPORT_NAME { get => eMPLOYEE_REPORT_NAME; set => eMPLOYEE_REPORT_NAME = value; }
        public static string CLIENT_REPORT_NAME { get => cLIENT_REPORT_NAME; set => cLIENT_REPORT_NAME = value; }
        public static string PRODUCT_BRAND_REPORT_NAME { get => pRODUCT_BRAND_REPORT_NAME; set => pRODUCT_BRAND_REPORT_NAME = value; }
        public static string PRODUCT_VENDOR_REPORT_NAME { get => pRODUCT_VENDOR_REPORT_NAME; set => pRODUCT_VENDOR_REPORT_NAME = value; }
        public static string PAYMENT_METHOD_REPORT_NAME { get => pAYMENT_METHOD_REPORT_NAME; set => pAYMENT_METHOD_REPORT_NAME = value; }
        public static string DELIVERY_SERVICE_REPORT_NAME { get => dELIVERY_SERVICE_REPORT_NAME; set => dELIVERY_SERVICE_REPORT_NAME = value; }
        public static string PRODUCT_REPORT_NAME { get => pRODUCT_REPORT_NAME; set => pRODUCT_REPORT_NAME = value; }
        public static string PRODUCT_ORDER_REPORT_NAME { get => pRODUCT_ORDER_REPORT_NAME; set => pRODUCT_ORDER_REPORT_NAME = value; }
        public static string PRODUCT_ORDER_INVOICE_REPORT_NAME { get => pRODUCT_ORDER_INVOICE_REPORT_NAME; set => pRODUCT_ORDER_INVOICE_REPORT_NAME = value; }
        public static string ORDER_DELIVERY_REPORT_NAME { get => oRDER_DELIVERY_REPORT_NAME; set => oRDER_DELIVERY_REPORT_NAME = value; }
        public static string ORDER_DELIVERY_INVOICE_REPORT_NAME { get => oRDER_DELIVERY_INVOICE_REPORT_NAME; set => oRDER_DELIVERY_INVOICE_REPORT_NAME = value; }
        public static string CRITICAL_ERROR_MESSAGE { get => cRITICAL_ERROR_MESSAGE; set => cRITICAL_ERROR_MESSAGE = value; }
        public static string CRITICAL_ERROR_INNER_EXCEPTION_DETAILS { get => cRITICAL_ERROR_INNER_EXCEPTION_DETAILS; set => cRITICAL_ERROR_INNER_EXCEPTION_DETAILS = value; }
        public static string STACK_TRACE_MESSAGE { get => sTACK_TRACE_MESSAGE; set => sTACK_TRACE_MESSAGE = value; }
        public static string CRITICAL_ERROR_TITLE { get => cRITICAL_ERROR_TITLE; set => cRITICAL_ERROR_TITLE = value; }
        public static string CLOSE_PROMPT { get => cLOSE_PROMPT; set => cLOSE_PROMPT = value; }
        public static string CLOSE_PROMPT_TITLE { get => cLOSE_PROMPT_TITLE; set => cLOSE_PROMPT_TITLE = value; }
        public static string APPLICATION_INSTANCE_ERROR_MESSAGE { get => aPPLICATION_INSTANCE_ERROR_MESSAGE; set => aPPLICATION_INSTANCE_ERROR_MESSAGE = value; }
        public static string CONNECTION_SUCCESSFUL_MESSAGE { get => cONNECTION_SUCCESSFUL_MESSAGE; set => cONNECTION_SUCCESSFUL_MESSAGE = value; }
        public static string CONNECTION_SUCCESSFUL_LOGIN_MESSAGE { get => cONNECTION_SUCCESSFUL_LOGIN_MESSAGE; set => cONNECTION_SUCCESSFUL_LOGIN_MESSAGE = value; }
        public static string CONNECTION_FAILED_MESSAGE { get => cONNECTION_FAILED_MESSAGE; set => cONNECTION_FAILED_MESSAGE = value; }
        public static string CONNECTION_FAILED_AFTER_RETRY_MESSAGE { get => cONNECTION_FAILED_AFTER_RETRY_MESSAGE; set => cONNECTION_FAILED_AFTER_RETRY_MESSAGE = value; }
        public static string CONNECTION_FAILED_LOGIN_MESSAGE { get => cONNECTION_FAILED_LOGIN_MESSAGE; set => cONNECTION_FAILED_LOGIN_MESSAGE = value; }
        public static string AUTHORISATION_ERROR_NO_LOGIN_MESSAGE { get => aUTHORISATION_ERROR_NO_LOGIN_MESSAGE; set => aUTHORISATION_ERROR_NO_LOGIN_MESSAGE = value; }
        public static string AUTHORISATION_ERROR_CANCELLED_LOGIN_MESSAGE { get => aUTHORISATION_ERROR_CANCELLED_LOGIN_MESSAGE; set => aUTHORISATION_ERROR_CANCELLED_LOGIN_MESSAGE = value; }
        public static string AUTHORISATION_ERROR_CLIENT_LOGIN_MESSAGE { get => aUTHORISATION_ERROR_CLIENT_LOGIN_MESSAGE; set => aUTHORISATION_ERROR_CLIENT_LOGIN_MESSAGE = value; }
        public static string AUTHORISATION_ERROR_SYSADMIN_BREACH_MESSAGE { get => aUTHORISATION_ERROR_SYSADMIN_BREACH_MESSAGE; set => aUTHORISATION_ERROR_SYSADMIN_BREACH_MESSAGE = value; }
        public static string AUTHORISATION_APPCONF_LOGIN_FOUND_MESSAGE { get => aUTHORISATION_APPCONF_LOGIN_FOUND_MESSAGE; set => aUTHORISATION_APPCONF_LOGIN_FOUND_MESSAGE = value; }
        public static string AUTHORISATION_APPCONF_LOGIN_NOT_FOUND_MESSAGE { get => aUTHORISATION_APPCONF_LOGIN_NOT_FOUND_MESSAGE; set => aUTHORISATION_APPCONF_LOGIN_NOT_FOUND_MESSAGE = value; }
        public static string AUTHORISATION_LOGIN_EMPTY_INPUT_MESSAGE { get => aUTHORISATION_LOGIN_EMPTY_INPUT_MESSAGE; set => aUTHORISATION_LOGIN_EMPTY_INPUT_MESSAGE = value; }
        public static string AUTHORISATION_LOGIN_INVALID_INPUT_MESSAGE { get => aUTHORISATION_LOGIN_INVALID_INPUT_MESSAGE; set => aUTHORISATION_LOGIN_INVALID_INPUT_MESSAGE = value; }
        public static string AUTHORISATION_ADD_LOGIN_INVALID_RESULTS_MESSAGE { get => aUTHORISATION_ADD_LOGIN_INVALID_RESULTS_MESSAGE; set => aUTHORISATION_ADD_LOGIN_INVALID_RESULTS_MESSAGE = value; }
        public static string AUTHORISATION_LOGIN_NO_CONNECTION_MESSAGE { get => aUTHORISATION_LOGIN_NO_CONNECTION_MESSAGE; set => aUTHORISATION_LOGIN_NO_CONNECTION_MESSAGE = value; }
        public static string AUTHORISATION_LOGIN_FILESYSTEM_LOAD_ERROR_MESSAGE { get => aUTHORISATION_LOGIN_FILESYSTEM_LOAD_ERROR_MESSAGE; set => aUTHORISATION_LOGIN_FILESYSTEM_LOAD_ERROR_MESSAGE = value; }
        public static string AUTHORISATION_LOGIN_EMPLOYEE_NOTICE { get => aUTHORISATION_LOGIN_EMPLOYEE_NOTICE; set => aUTHORISATION_LOGIN_EMPLOYEE_NOTICE = value; }
        public static string AUTHORISATION_LOGIN_ADMIN_NOTICE { get => aUTHORISATION_LOGIN_ADMIN_NOTICE; set => aUTHORISATION_LOGIN_ADMIN_NOTICE = value; }
        public static string USER_ACCESS_TITLE { get => uSER_ACCESS_TITLE; set => uSER_ACCESS_TITLE = value; }
        public static string PRODUCT_MENU_ACCESS_ADMIN_NOTICE { get => pRODUCT_MENU_ACCESS_ADMIN_NOTICE; set => pRODUCT_MENU_ACCESS_ADMIN_NOTICE = value; }
        public static string PRODUCT_MENU_ACCESS_EMPLOYEE_NOTICE { get => pRODUCT_MENU_ACCESS_EMPLOYEE_NOTICE; set => pRODUCT_MENU_ACCESS_EMPLOYEE_NOTICE = value; }
        public static string USER_MENU_ACCESS_ERROR_MESSAGE { get => uSER_MENU_ACCESS_ERROR_MESSAGE; set => uSER_MENU_ACCESS_ERROR_MESSAGE = value; }
        public static string BRAND_MENU_ACCESS_ERROR_MESSAGE { get => bRAND_MENU_ACCESS_ERROR_MESSAGE; set => bRAND_MENU_ACCESS_ERROR_MESSAGE = value; }
        public static string VENDOR_MENU_ACCESS_ERROR_MESSAGE { get => vENDOR_MENU_ACCESS_ERROR_MESSAGE; set => vENDOR_MENU_ACCESS_ERROR_MESSAGE = value; }
        public static string PAYMENT_METHOD_MENU_ACCESS_ERROR_MESSAGE { get => pAYMENT_METHOD_MENU_ACCESS_ERROR_MESSAGE; set => pAYMENT_METHOD_MENU_ACCESS_ERROR_MESSAGE = value; }
        public static string DELIVERY_SERVICE_MENU_ACCESS_ERROR_MESSAGE { get => dELIVERY_SERVICE_MENU_ACCESS_ERROR_MESSAGE; set => dELIVERY_SERVICE_MENU_ACCESS_ERROR_MESSAGE = value; }
        public static string PRODUCT_MENU_ACCESS_ERROR_MESSAGE { get => pRODUCT_MENU_ACCESS_ERROR_MESSAGE; set => pRODUCT_MENU_ACCESS_ERROR_MESSAGE = value; }
        public static string PRODUCT_ORDER_MENU_ACCESS_ERROR_MESSAGE { get => pRODUCT_ORDER_MENU_ACCESS_ERROR_MESSAGE; set => pRODUCT_ORDER_MENU_ACCESS_ERROR_MESSAGE = value; }
        public static string ORDER_DELIVERY_MENU_ACCESS_ERROR_MESSAGE { get => oRDER_DELIVERY_MENU_ACCESS_ERROR_MESSAGE; set => oRDER_DELIVERY_MENU_ACCESS_ERROR_MESSAGE = value; }
        public static string LOGS_MENU_ACCESS_ERROR_MESSAGE { get => lOGS_MENU_ACCESS_ERROR_MESSAGE; set => lOGS_MENU_ACCESS_ERROR_MESSAGE = value; }
        public static string BULK_USER_MENU_ACCESS_ERROR_MESSAGE { get => bULK_USER_MENU_ACCESS_ERROR_MESSAGE; set => bULK_USER_MENU_ACCESS_ERROR_MESSAGE = value; }
        public static string BULK_BRAND_MENU_ACCESS_ERROR_MESSAGE { get => bULK_BRAND_MENU_ACCESS_ERROR_MESSAGE; set => bULK_BRAND_MENU_ACCESS_ERROR_MESSAGE = value; }
        public static string BULK_VENDOR_MENU_ACCESS_ERROR_MESSAGE { get => bULK_VENDOR_MENU_ACCESS_ERROR_MESSAGE; set => bULK_VENDOR_MENU_ACCESS_ERROR_MESSAGE = value; }
        public static string BULK_PAYMENT_METHOD_MENU_ACCESS_ERROR_MESSAGE { get => bULK_PAYMENT_METHOD_MENU_ACCESS_ERROR_MESSAGE; set => bULK_PAYMENT_METHOD_MENU_ACCESS_ERROR_MESSAGE = value; }
        public static string BULK_DELIVERY_SERVICE_MENU_ACCESS_ERROR_MESSAGE { get => bULK_DELIVERY_SERVICE_MENU_ACCESS_ERROR_MESSAGE; set => bULK_DELIVERY_SERVICE_MENU_ACCESS_ERROR_MESSAGE = value; }
        public static string BULK_PRODUCT_MENU_ACCESS_ERROR_MESSAGE { get => bULK_PRODUCT_MENU_ACCESS_ERROR_MESSAGE; set => bULK_PRODUCT_MENU_ACCESS_ERROR_MESSAGE = value; }
        public static string BULK_PRODUCT_IMAGE_MENU_ACCESS_ERROR_MESSAGE { get => bULK_PRODUCT_IMAGE_MENU_ACCESS_ERROR_MESSAGE; set => bULK_PRODUCT_IMAGE_MENU_ACCESS_ERROR_MESSAGE = value; }
        public static string BULK_PRODUCT_ORDER_MENU_ACCESS_ERROR_MESSAGE { get => bULK_PRODUCT_ORDER_MENU_ACCESS_ERROR_MESSAGE; set => bULK_PRODUCT_ORDER_MENU_ACCESS_ERROR_MESSAGE = value; }
        public static string BULK_ORDER_DELIVERY_MENU_ACCESS_ERROR_MESSAGE { get => bULK_ORDER_DELIVERY_MENU_ACCESS_ERROR_MESSAGE; set => bULK_ORDER_DELIVERY_MENU_ACCESS_ERROR_MESSAGE = value; }
        public static string ACCOUNT_SETTINGS_ERROR_MESSAGE { get => aCCOUNT_SETTINGS_ERROR_MESSAGE; set => aCCOUNT_SETTINGS_ERROR_MESSAGE = value; }
        public static string ACCOUNT_SETTINGS_INVALID_CREDENTIALS_ERROR_MESSAGE { get => aCCOUNT_SETTINGS_INVALID_CREDENTIALS_ERROR_MESSAGE; set => aCCOUNT_SETTINGS_INVALID_CREDENTIALS_ERROR_MESSAGE = value; }
        public static string LANGUAGE_MANAGER_LANGUAGE_EXIST_ERROR_MESSAGE { get => lANGUAGE_MANAGER_LANGUAGE_EXIST_ERROR_MESSAGE; set => lANGUAGE_MANAGER_LANGUAGE_EXIST_ERROR_MESSAGE = value; }
        public static string LANGUAGE_MANAGER_LANGUAGE_NONEXISTENT_ERROR_MESSAGE { get => lANGUAGE_MANAGER_LANGUAGE_NONEXISTENT_ERROR_MESSAGE; set => lANGUAGE_MANAGER_LANGUAGE_NONEXISTENT_ERROR_MESSAGE = value; }
        public static string REPORT_GENERATION_PERMISSION_ERROR { get => rEPORT_GENERATION_PERMISSION_ERROR; set => rEPORT_GENERATION_PERMISSION_ERROR = value; }
        public static string RECORD_DELETION_WARNING { get => rECORD_DELETION_WARNING; set => rECORD_DELETION_WARNING = value; }
        public static string USER_EDIT_OPERATION_PERMISSION_ERROR { get => uSER_EDIT_OPERATION_PERMISSION_ERROR; set => uSER_EDIT_OPERATION_PERMISSION_ERROR = value; }
        public static string USER_DELETE_OPERATION_PERMISSION_ERROR { get => uSER_DELETE_OPERATION_PERMISSION_ERROR; set => uSER_DELETE_OPERATION_PERMISSION_ERROR = value; }
        public static string VENDOR_EDIT_OPERATION_PERMISSION_ERROR { get => vENDOR_EDIT_OPERATION_PERMISSION_ERROR; set => vENDOR_EDIT_OPERATION_PERMISSION_ERROR = value; }
        public static string VENDOR_DELETE_OPERATION_PERMISSION_ERROR { get => vENDOR_DELETE_OPERATION_PERMISSION_ERROR; set => vENDOR_DELETE_OPERATION_PERMISSION_ERROR = value; }
        public static string PRODUCT_EDIT_OPERATION_PERMISSION_ERROR { get => pRODUCT_EDIT_OPERATION_PERMISSION_ERROR; set => pRODUCT_EDIT_OPERATION_PERMISSION_ERROR = value; }
        public static string PRODUCT_DELETE_OPERATION_PERMISSION_ERROR { get => pRODUCT_DELETE_OPERATION_PERMISSION_ERROR; set => pRODUCT_DELETE_OPERATION_PERMISSION_ERROR = value; }
        public static string PRODUCT_IMAGE_EDIT_OPERATION_PERMISSION_ERROR { get => pRODUCT_IMAGE_EDIT_OPERATION_PERMISSION_ERROR; set => pRODUCT_IMAGE_EDIT_OPERATION_PERMISSION_ERROR = value; }
        public static string PRODUCT_IMAGE_DELETE_OPERATION_PERMISSION_ERROR { get => pRODUCT_IMAGE_DELETE_OPERATION_PERMISSION_ERROR; set => pRODUCT_IMAGE_DELETE_OPERATION_PERMISSION_ERROR = value; }
        public static string PRODUCT_ORDER_TOTAL_PRICE_OVERRIDE_QUESTION { get => pRODUCT_ORDER_TOTAL_PRICE_OVERRIDE_QUESTION; set => pRODUCT_ORDER_TOTAL_PRICE_OVERRIDE_QUESTION = value; }
        public static string BULK_PRODUCT_ORDER_TOTAL_PRICE_OVERRIDE_QUESTION { get => bULK_PRODUCT_ORDER_TOTAL_PRICE_OVERRIDE_QUESTION; set => bULK_PRODUCT_ORDER_TOTAL_PRICE_OVERRIDE_QUESTION = value; }
        public static string PRODUCT_ORDER_DELETE_OPERATION_PERMISSION_ERROR { get => pRODUCT_ORDER_DELETE_OPERATION_PERMISSION_ERROR; set => pRODUCT_ORDER_DELETE_OPERATION_PERMISSION_ERROR = value; }
        public static string PRODUCT_ORDER_EDIT_OPERATION_PERMISSION_ERROR { get => pRODUCT_ORDER_EDIT_OPERATION_PERMISSION_ERROR; set => pRODUCT_ORDER_EDIT_OPERATION_PERMISSION_ERROR = value; }
        public static string PRODUCT_ORDER_INVOICE_GENERATION_QUESTION { get => pRODUCT_ORDER_INVOICE_GENERATION_QUESTION; set => pRODUCT_ORDER_INVOICE_GENERATION_QUESTION = value; }
        public static string ORDER_DELIVERY_DELETE_OPERATION_PERMISSION_ERROR { get => oRDER_DELIVERY_DELETE_OPERATION_PERMISSION_ERROR; set => oRDER_DELIVERY_DELETE_OPERATION_PERMISSION_ERROR = value; }
        public static string ORDER_DELIVERY_EDIT_OPERATION_PERMISSION_ERROR { get => oRDER_DELIVERY_EDIT_OPERATION_PERMISSION_ERROR; set => oRDER_DELIVERY_EDIT_OPERATION_PERMISSION_ERROR = value; }
        public static string ORDER_DELIVERY_INVOICE_GENERATION_QUESTION { get => oRDER_DELIVERY_INVOICE_GENERATION_QUESTION; set => oRDER_DELIVERY_INVOICE_GENERATION_QUESTION = value; }
        public static string BRAND_EDIT_OPERATION_PERMISSION_ERROR { get => bRAND_EDIT_OPERATION_PERMISSION_ERROR; set => bRAND_EDIT_OPERATION_PERMISSION_ERROR = value; }
        public static string BRAND_DELETE_OPERATION_PERMISSION_ERROR { get => bRAND_DELETE_OPERATION_PERMISSION_ERROR; set => bRAND_DELETE_OPERATION_PERMISSION_ERROR = value; }
        public static string PAYMENT_METHOD_EDIT_OPERATION_PERMISSION_ERROR { get => pAYMENT_METHOD_EDIT_OPERATION_PERMISSION_ERROR; set => pAYMENT_METHOD_EDIT_OPERATION_PERMISSION_ERROR = value; }
        public static string PAYMENT_METHOD_DELETE_OPERATION_PERMISSION_ERROR { get => pAYMENT_METHOD_DELETE_OPERATION_PERMISSION_ERROR; set => pAYMENT_METHOD_DELETE_OPERATION_PERMISSION_ERROR = value; }
        public static string DELIVERY_SERVICE_EDIT_OPERATION_PERMISSION_ERROR { get => dELIVERY_SERVICE_EDIT_OPERATION_PERMISSION_ERROR; set => dELIVERY_SERVICE_EDIT_OPERATION_PERMISSION_ERROR = value; }
        public static string DELIVERY_SERVICE_DELETE_OPERATION_PERMISSION_ERROR { get => dELIVERY_SERVICE_DELETE_OPERATION_PERMISSION_ERROR; set => dELIVERY_SERVICE_DELETE_OPERATION_PERMISSION_ERROR = value; }
        public static string IMAGE_BIN_CONVERTER_CONVERT_IMAGE_TITLE { get => iMAGE_BIN_CONVERTER_CONVERT_IMAGE_TITLE; set => iMAGE_BIN_CONVERTER_CONVERT_IMAGE_TITLE = value; }
        public static string APPLICATION_SETTINGS_CHANGES_NOTICE { get => aPPLICATION_SETTINGS_CHANGES_NOTICE; set => aPPLICATION_SETTINGS_CHANGES_NOTICE = value; }
        public static string BULK_OPERATION_QUESTION { get => bULK_OPERATION_QUESTION; set => bULK_OPERATION_QUESTION = value; }
        public static string BULK_OPERATION_OPERATION_ON_NAME { get => bULK_OPERATION_OPERATION_ON_NAME; set => bULK_OPERATION_OPERATION_ON_NAME = value; }
        public static string BULK_OPERATION_OPERATION_ON_TARGET_ID_NAME { get => bULK_OPERATION_OPERATION_ON_TARGET_ID_NAME; set => bULK_OPERATION_OPERATION_ON_TARGET_ID_NAME = value; }
        public static string BULK_OPERATION_UNAUTHORISED_ERROR_MESSAGE { get => bULK_OPERATION_UNAUTHORISED_ERROR_MESSAGE; set => bULK_OPERATION_UNAUTHORISED_ERROR_MESSAGE = value; }
        public static string BULK_USER_OPERATION_UNAUTHORISED_ERROR_MESSAGE { get => bULK_USER_OPERATION_UNAUTHORISED_ERROR_MESSAGE; set => bULK_USER_OPERATION_UNAUTHORISED_ERROR_MESSAGE = value; }
        public static string BULK_BRAND_OPERATION_UNAUTHORISED_ERROR_MESSAGE { get => bULK_BRAND_OPERATION_UNAUTHORISED_ERROR_MESSAGE; set => bULK_BRAND_OPERATION_UNAUTHORISED_ERROR_MESSAGE = value; }
        public static string BULK_VENDOR_OPERATION_UNAUTHORISED_ERROR_MESSAGE { get => bULK_VENDOR_OPERATION_UNAUTHORISED_ERROR_MESSAGE; set => bULK_VENDOR_OPERATION_UNAUTHORISED_ERROR_MESSAGE = value; }
        public static string BULK_PAYMENT_METHOD_OPERATION_UNAUTHORISED_ERROR_MESSAGE { get => bULK_PAYMENT_METHOD_OPERATION_UNAUTHORISED_ERROR_MESSAGE; set => bULK_PAYMENT_METHOD_OPERATION_UNAUTHORISED_ERROR_MESSAGE = value; }
        public static string BULK_DELIVERY_SERVICE_OPERATION_UNAUTHORISED_ERROR_MESSAGE { get => bULK_DELIVERY_SERVICE_OPERATION_UNAUTHORISED_ERROR_MESSAGE; set => bULK_DELIVERY_SERVICE_OPERATION_UNAUTHORISED_ERROR_MESSAGE = value; }
        public static string BULK_PRODUCT_OPERATION_UNAUTHORISED_ERROR_MESSAGE { get => bULK_PRODUCT_OPERATION_UNAUTHORISED_ERROR_MESSAGE; set => bULK_PRODUCT_OPERATION_UNAUTHORISED_ERROR_MESSAGE = value; }
        public static string BULK_PRODUCT_IMAGE_OPERATION_UNAUTHORISED_ERROR_MESSAGE { get => bULK_PRODUCT_IMAGE_OPERATION_UNAUTHORISED_ERROR_MESSAGE; set => bULK_PRODUCT_IMAGE_OPERATION_UNAUTHORISED_ERROR_MESSAGE = value; }
        public static string BULK_PRODUCT_ORDER_OPERATION_UNAUTHORISED_ERROR_MESSAGE { get => bULK_PRODUCT_ORDER_OPERATION_UNAUTHORISED_ERROR_MESSAGE; set => bULK_PRODUCT_ORDER_OPERATION_UNAUTHORISED_ERROR_MESSAGE = value; }
        public static string BULK_ORDER_DELIVERY_OPERATION_UNAUTHORISED_ERROR_MESSAGE { get => bULK_ORDER_DELIVERY_OPERATION_UNAUTHORISED_ERROR_MESSAGE; set => bULK_ORDER_DELIVERY_OPERATION_UNAUTHORISED_ERROR_MESSAGE = value; }
        public static string SAMPLE_BULK_OPERATION_CREATE_TASK_SUCCESS_MESSAGE { get => sAMPLE_BULK_OPERATION_CREATE_TASK_SUCCESS_MESSAGE; set => sAMPLE_BULK_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = value; }
        public static string SAMPLE_BULK_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE { get => sAMPLE_BULK_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE; set => sAMPLE_BULK_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = value; }
        public static string SAMPLE_BULK_OPERATION_DELETE_TASK_SUCCESS_MESSAGE { get => sAMPLE_BULK_OPERATION_DELETE_TASK_SUCCESS_MESSAGE; set => sAMPLE_BULK_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = value; }
        public static string SAMPLE_BULK_OPERATION_CUSTOM_TASK_SUCCESS_MESSAGE { get => sAMPLE_BULK_OPERATION_CUSTOM_TASK_SUCCESS_MESSAGE; set => sAMPLE_BULK_OPERATION_CUSTOM_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_USER_OPERATION_CREATE_TASK_SUCCESS_MESSAGE { get => bULK_USER_OPERATION_CREATE_TASK_SUCCESS_MESSAGE; set => bULK_USER_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_USER_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE { get => bULK_USER_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE; set => bULK_USER_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_USER_OPERATION_DELETE_TASK_SUCCESS_MESSAGE { get => bULK_USER_OPERATION_DELETE_TASK_SUCCESS_MESSAGE; set => bULK_USER_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_BRAND_OPERATION_CREATE_TASK_SUCCESS_MESSAGE { get => bULK_BRAND_OPERATION_CREATE_TASK_SUCCESS_MESSAGE; set => bULK_BRAND_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_BRAND_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE { get => bULK_BRAND_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE; set => bULK_BRAND_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_BRAND_OPERATION_DELETE_TASK_SUCCESS_MESSAGE { get => bULK_BRAND_OPERATION_DELETE_TASK_SUCCESS_MESSAGE; set => bULK_BRAND_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_VENDOR_OPERATION_CREATE_TASK_SUCCESS_MESSAGE { get => bULK_VENDOR_OPERATION_CREATE_TASK_SUCCESS_MESSAGE; set => bULK_VENDOR_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_VENDOR_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE { get => bULK_VENDOR_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE; set => bULK_VENDOR_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_VENDOR_OPERATION_DELETE_TASK_SUCCESS_MESSAGE { get => bULK_VENDOR_OPERATION_DELETE_TASK_SUCCESS_MESSAGE; set => bULK_VENDOR_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_PAYMENT_METHOD_OPERATION_CREATE_TASK_SUCCESS_MESSAGE { get => bULK_PAYMENT_METHOD_OPERATION_CREATE_TASK_SUCCESS_MESSAGE; set => bULK_PAYMENT_METHOD_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_PAYMENT_METHOD_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE { get => bULK_PAYMENT_METHOD_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE; set => bULK_PAYMENT_METHOD_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_PAYMENT_METHOD_OPERATION_DELETE_TASK_SUCCESS_MESSAGE { get => bULK_PAYMENT_METHOD_OPERATION_DELETE_TASK_SUCCESS_MESSAGE; set => bULK_PAYMENT_METHOD_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_DELIVERY_SERVICE_OPERATION_CREATE_TASK_SUCCESS_MESSAGE { get => bULK_DELIVERY_SERVICE_OPERATION_CREATE_TASK_SUCCESS_MESSAGE; set => bULK_DELIVERY_SERVICE_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_DELIVERY_SERVICE_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE { get => bULK_DELIVERY_SERVICE_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE; set => bULK_DELIVERY_SERVICE_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_DELIVERY_SERVICE_OPERATION_DELETE_TASK_SUCCESS_MESSAGE { get => bULK_DELIVERY_SERVICE_OPERATION_DELETE_TASK_SUCCESS_MESSAGE; set => bULK_DELIVERY_SERVICE_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_PRODUCT_OPERATION_CREATE_TASK_SUCCESS_MESSAGE { get => bULK_PRODUCT_OPERATION_CREATE_TASK_SUCCESS_MESSAGE; set => bULK_PRODUCT_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_PRODUCT_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE { get => bULK_PRODUCT_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE; set => bULK_PRODUCT_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_PRODUCT_OPERATION_DELETE_TASK_SUCCESS_MESSAGE { get => bULK_PRODUCT_OPERATION_DELETE_TASK_SUCCESS_MESSAGE; set => bULK_PRODUCT_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_PRODUCT_IMAGE_OPERATION_CREATE_TASK_SUCCESS_MESSAGE { get => bULK_PRODUCT_IMAGE_OPERATION_CREATE_TASK_SUCCESS_MESSAGE; set => bULK_PRODUCT_IMAGE_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_PRODUCT_IMAGE_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE { get => bULK_PRODUCT_IMAGE_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE; set => bULK_PRODUCT_IMAGE_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_PRODUCT_IMAGE_OPERATION_DELETE_TASK_SUCCESS_MESSAGE { get => bULK_PRODUCT_IMAGE_OPERATION_DELETE_TASK_SUCCESS_MESSAGE; set => bULK_PRODUCT_IMAGE_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_PRODUCT_ORDER_OPERATION_CREATE_TASK_SUCCESS_MESSAGE { get => bULK_PRODUCT_ORDER_OPERATION_CREATE_TASK_SUCCESS_MESSAGE; set => bULK_PRODUCT_ORDER_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_PRODUCT_ORDER_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE { get => bULK_PRODUCT_ORDER_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE; set => bULK_PRODUCT_ORDER_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_PRODUCT_ORDER_OPERATION_DELETE_TASK_SUCCESS_MESSAGE { get => bULK_PRODUCT_ORDER_OPERATION_DELETE_TASK_SUCCESS_MESSAGE; set => bULK_PRODUCT_ORDER_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_ORDER_DELIVERY_OPERATION_CREATE_TASK_SUCCESS_MESSAGE { get => bULK_ORDER_DELIVERY_OPERATION_CREATE_TASK_SUCCESS_MESSAGE; set => bULK_ORDER_DELIVERY_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_ORDER_DELIVERY_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE { get => bULK_ORDER_DELIVERY_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE; set => bULK_ORDER_DELIVERY_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_ORDER_DELIVERY_OPERATION_DELETE_TASK_SUCCESS_MESSAGE { get => bULK_ORDER_DELIVERY_OPERATION_DELETE_TASK_SUCCESS_MESSAGE; set => bULK_ORDER_DELIVERY_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = value; }
        public static string BULK_OPERATION_START_TIME_MESSAGE { get => bULK_OPERATION_START_TIME_MESSAGE; set => bULK_OPERATION_START_TIME_MESSAGE = value; }
        public static string BULK_OPERATION_EXECUTING_MESSAGE { get => bULK_OPERATION_EXECUTING_MESSAGE; set => bULK_OPERATION_EXECUTING_MESSAGE = value; }
        public static string BULK_OPERATION_SUCCESSFUL_MESSAGE { get => bULK_OPERATION_SUCCESSFUL_MESSAGE; set => bULK_OPERATION_SUCCESSFUL_MESSAGE = value; }
        public static string BULK_OPERATION_FAILED_MESSAGE { get => bULK_OPERATION_FAILED_MESSAGE; set => bULK_OPERATION_FAILED_MESSAGE = value; }
        public static string BULK_OPERATION_ERROR_CODE_MESSAGE { get => bULK_OPERATION_ERROR_CODE_MESSAGE; set => bULK_OPERATION_ERROR_CODE_MESSAGE = value; }
        public static string BULK_OPERATION_ERROR_MESSAGE { get => bULK_OPERATION_ERROR_MESSAGE; set => bULK_OPERATION_ERROR_MESSAGE = value; }
        public static string BULK_OPERATION_END_TIME_MESSAGE { get => bULK_OPERATION_END_TIME_MESSAGE; set => bULK_OPERATION_END_TIME_MESSAGE = value; }
        public static string BULK_OPERATION_RESULTS_MESSAGE { get => bULK_OPERATION_RESULTS_MESSAGE; set => bULK_OPERATION_RESULTS_MESSAGE = value; }
        public static string BULK_OPERATION_COMPLETED_COUNT_MESSAGE { get => bULK_OPERATION_COMPLETED_COUNT_MESSAGE; set => bULK_OPERATION_COMPLETED_COUNT_MESSAGE = value; }
        public static string BULK_OPERATION_FAILED_COUNT_MESSAGE { get => bULK_OPERATION_FAILED_COUNT_MESSAGE; set => bULK_OPERATION_FAILED_COUNT_MESSAGE = value; }
        public static string BULK_OPERATION_EXECUTION_TIME_MESSAGE { get => bULK_OPERATION_EXECUTION_TIME_MESSAGE; set => bULK_OPERATION_EXECUTION_TIME_MESSAGE = value; }
        public static string BULK_USER_OPERATION_NO_PERMISSION_MESSAGE { get => bULK_USER_OPERATION_NO_PERMISSION_MESSAGE; set => bULK_USER_OPERATION_NO_PERMISSION_MESSAGE = value; }
        public static string BULK_BRAND_OPERATION_NO_PERMISSION_MESSAGE { get => bULK_BRAND_OPERATION_NO_PERMISSION_MESSAGE; set => bULK_BRAND_OPERATION_NO_PERMISSION_MESSAGE = value; }
        public static string BULK_VENDOR_OPERATION_NO_PERMISSION_MESSAGE { get => bULK_VENDOR_OPERATION_NO_PERMISSION_MESSAGE; set => bULK_VENDOR_OPERATION_NO_PERMISSION_MESSAGE = value; }
        public static string BULK_PAYMENT_METHOD_OPERATION_NO_PERMISSION_MESSAGE { get => bULK_PAYMENT_METHOD_OPERATION_NO_PERMISSION_MESSAGE; set => bULK_PAYMENT_METHOD_OPERATION_NO_PERMISSION_MESSAGE = value; }
        public static string BULK_DELIVERY_SERVICE_OPERATION_NO_PERMISSION_MESSAGE { get => bULK_DELIVERY_SERVICE_OPERATION_NO_PERMISSION_MESSAGE; set => bULK_DELIVERY_SERVICE_OPERATION_NO_PERMISSION_MESSAGE = value; }
        public static string BULK_PRODUCT_OPERATION_NO_PERMISSION_MESSAGE { get => bULK_PRODUCT_OPERATION_NO_PERMISSION_MESSAGE; set => bULK_PRODUCT_OPERATION_NO_PERMISSION_MESSAGE = value; }
        public static string BULK_PRODUCT_IMAGE_OPERATION_NO_PERMISSION_MESSAGE { get => bULK_PRODUCT_IMAGE_OPERATION_NO_PERMISSION_MESSAGE; set => bULK_PRODUCT_IMAGE_OPERATION_NO_PERMISSION_MESSAGE = value; }
        public static string BULK_PRODUCT_ORDER_OPERATION_NO_PERMISSION_MESSAGE { get => bULK_PRODUCT_ORDER_OPERATION_NO_PERMISSION_MESSAGE; set => bULK_PRODUCT_ORDER_OPERATION_NO_PERMISSION_MESSAGE = value; }
        public static string BULK_ORDER_DELIVERY_OPERATION_NO_PERMISSION_MESSAGE { get => bULK_ORDER_DELIVERY_OPERATION_NO_PERMISSION_MESSAGE; set => bULK_ORDER_DELIVERY_OPERATION_NO_PERMISSION_MESSAGE = value; }
        public static string LBL_BULK_OPERATION_RESULTS_TEXT { get => lBL_BULK_OPERATION_RESULTS_TEXT; set => lBL_BULK_OPERATION_RESULTS_TEXT = value; }
        public static string BULK_OPERATIONS_TITLE { get => bULK_OPERATIONS_TITLE; set => bULK_OPERATIONS_TITLE = value; }
        public static string TEST_TITLE { get => tEST_TITLE; set => tEST_TITLE = value; }
        public static string LOGIN_TITLE { get => lOGIN_TITLE; set => lOGIN_TITLE = value; }
        public static string WARNING_TITLE { get => wARNING_TITLE; set => wARNING_TITLE = value; }
        public static string CURRENT_HOST_TITLE { get => cURRENT_HOST_TITLE; set => cURRENT_HOST_TITLE = value; }
        public static string CURRENT_OPERATOR_TITLE { get => cURRENT_OPERATOR_TITLE; set => cURRENT_OPERATOR_TITLE = value; }
        public static string ACCOUNT_SETTINGS_TITLE { get => aCCOUNT_SETTINGS_TITLE; set => aCCOUNT_SETTINGS_TITLE = value; }
        public static string APPLICATION_SETTINGS_TITLE { get => aPPLICATION_SETTINGS_TITLE; set => aPPLICATION_SETTINGS_TITLE = value; }
        public static string ACCOUNT_SETTINGS_PROFILE_PIC_SELECT_TITLE { get => aCCOUNT_SETTINGS_PROFILE_PIC_SELECT_TITLE; set => aCCOUNT_SETTINGS_PROFILE_PIC_SELECT_TITLE = value; }
        public static string APPLICATION_SETTINGS_LOGINS_FOLDER_SELECT_TITLE { get => aPPLICATION_SETTINGS_LOGINS_FOLDER_SELECT_TITLE; set => aPPLICATION_SETTINGS_LOGINS_FOLDER_SELECT_TITLE = value; }
        public static string APPLICATION_SETTINGS_REPORTS_FOLDER_SELECT_TITLE { get => aPPLICATION_SETTINGS_REPORTS_FOLDER_SELECT_TITLE; set => aPPLICATION_SETTINGS_REPORTS_FOLDER_SELECT_TITLE = value; }
        public static string ABOUT_TITLE { get => aBOUT_TITLE; set => aBOUT_TITLE = value; }
        public static string VERSION_TITLE { get => vERSION_TITLE; set => vERSION_TITLE = value; }
        public static string ASSEMBLY_PRODUCT_NAME { get => aSSEMBLY_PRODUCT_NAME; set => aSSEMBLY_PRODUCT_NAME = value; }
        public static string ASSEMBLY_TITLE { get => aSSEMBLY_TITLE; set => aSSEMBLY_TITLE = value; }
        public static string NEW_ORDER_TITLE { get => nEW_ORDER_TITLE; set => nEW_ORDER_TITLE = value; }
        public static string REPORT_GENERATION_TITLE { get => rEPORT_GENERATION_TITLE; set => rEPORT_GENERATION_TITLE = value; }
        public static string IMAGE_UPLOAD_FOR_OPERATION_TITLE { get => iMAGE_UPLOAD_FOR_OPERATION_TITLE; set => iMAGE_UPLOAD_FOR_OPERATION_TITLE = value; }
        public static string USERS_TITLE { get => uSERS_TITLE; set => uSERS_TITLE = value; }
        public static string USERS_TOOLTIP_TITLE { get => uSERS_TOOLTIP_TITLE; set => uSERS_TOOLTIP_TITLE = value; }
        public static string ROLE_COL_TITLE { get => rOLE_COL_TITLE; set => rOLE_COL_TITLE = value; }
        public static string LBL_ROLE_ADMIN { get => lBL_ROLE_ADMIN; set => lBL_ROLE_ADMIN = value; }
        public static string LBL_ROLE_EMPLOYEE { get => lBL_ROLE_EMPLOYEE; set => lBL_ROLE_EMPLOYEE = value; }
        public static string LBL_ROLE_CLIENT { get => lBL_ROLE_CLIENT; set => lBL_ROLE_CLIENT = value; }
        public static string ROLE_SEARCH_TOOLTIP_TITLE { get => rOLE_SEARCH_TOOLTIP_TITLE; set => rOLE_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_ROLE_TITLE { get => lBL_ROLE_TITLE; set => lBL_ROLE_TITLE = value; }
        public static string REGISTER_DATE_COL_TITLE { get => rEGISTER_DATE_COL_TITLE; set => rEGISTER_DATE_COL_TITLE = value; }
        public static string DIAGNOSE_COL_TITLE { get => dIAGNOSE_COL_TITLE; set => dIAGNOSE_COL_TITLE = value; }
        public static string BALANCE_COL_TITLE { get => bALANCE_COL_TITLE; set => bALANCE_COL_TITLE = value; }
        public static string PROFILE_PIC_COL_TITLE { get => pROFILE_PIC_COL_TITLE; set => pROFILE_PIC_COL_TITLE = value; }
        public static string ADDRESS_COL_TITLE { get => aDDRESS_COL_TITLE; set => aDDRESS_COL_TITLE = value; }
        public static string EMAIL_COL_TITLE { get => eMAIL_COL_TITLE; set => eMAIL_COL_TITLE = value; }
        public static string PHONE_COL_TITLE { get => pHONE_COL_TITLE; set => pHONE_COL_TITLE = value; }
        public static string BIRTH_DATE_COL_TITLE { get => bIRTH_DATE_COL_TITLE; set => bIRTH_DATE_COL_TITLE = value; }
        public static string DISPLAY_NAME_COL_TITLE { get => dISPLAY_NAME_COL_TITLE; set => dISPLAY_NAME_COL_TITLE = value; }
        public static string PASSWORD_COL_TITLE { get => pASSWORD_COL_TITLE; set => pASSWORD_COL_TITLE = value; }
        public static string USER_NAME_COL_TITLE { get => uSER_NAME_COL_TITLE; set => uSER_NAME_COL_TITLE = value; }
        public static string USER_ID_COL_TITLE { get => uSER_ID_COL_TITLE; set => uSER_ID_COL_TITLE = value; }
        public static string HELP_TITLE { get => hELP_TITLE; set => hELP_TITLE = value; }
        public static string USER_NOTICE_TOOLTIP_TITLE { get => uSER_NOTICE_TOOLTIP_TITLE; set => uSER_NOTICE_TOOLTIP_TITLE = value; }
        public static string LBL_USER_NOTICE_TITLE { get => lBL_USER_NOTICE_TITLE; set => lBL_USER_NOTICE_TITLE = value; }
        public static string BTN_GENERATE_REPORT_TITLE { get => bTN_GENERATE_REPORT_TITLE; set => bTN_GENERATE_REPORT_TITLE = value; }
        public static string BTN_GENERATE_REPORT_TOOLTIP_TITLE { get => bTN_GENERATE_REPORT_TOOLTIP_TITLE; set => bTN_GENERATE_REPORT_TOOLTIP_TITLE = value; }
        public static string BALANCE_SEARCH_TOOLTIP_TITLE { get => bALANCE_SEARCH_TOOLTIP_TITLE; set => bALANCE_SEARCH_TOOLTIP_TITLE = value; }
        public static string BTN_DELETE_TITLE { get => bTN_DELETE_TITLE; set => bTN_DELETE_TITLE = value; }
        public static string BTN_DELETE_TOOLTIP_TITLE { get => bTN_DELETE_TOOLTIP_TITLE; set => bTN_DELETE_TOOLTIP_TITLE = value; }
        public static string BTN_ADD_EDIT_TITLE { get => bTN_ADD_EDIT_TITLE; set => bTN_ADD_EDIT_TITLE = value; }
        public static string BTN_ADD_EDIT_TOOLTIP_TITLE { get => bTN_ADD_EDIT_TOOLTIP_TITLE; set => bTN_ADD_EDIT_TOOLTIP_TITLE = value; }
        public static string LBL_SEARCH_MODE_TITLE { get => lBL_SEARCH_MODE_TITLE; set => lBL_SEARCH_MODE_TITLE = value; }
        public static string LBL_SEARCH_MODE_NONE { get => lBL_SEARCH_MODE_NONE; set => lBL_SEARCH_MODE_NONE = value; }
        public static string LBL_SEARCH_MODE_SINGLE { get => lBL_SEARCH_MODE_SINGLE; set => lBL_SEARCH_MODE_SINGLE = value; }
        public static string LBL_SEARCH_MODE_MULTIPLE { get => lBL_SEARCH_MODE_MULTIPLE; set => lBL_SEARCH_MODE_MULTIPLE = value; }
        public static string LBL_SEARCH_MODE_ALL { get => lBL_SEARCH_MODE_ALL; set => lBL_SEARCH_MODE_ALL = value; }
        public static string BTN_SEARCH_TITLE { get => bTN_SEARCH_TITLE; set => bTN_SEARCH_TITLE = value; }
        public static string BTN_SEARCH_TOOLTIP_TITLE { get => bTN_SEARCH_TOOLTIP_TITLE; set => bTN_SEARCH_TOOLTIP_TITLE = value; }
        public static string CB_SEARCH_MODE_TOOLTIP_TITLE { get => cB_SEARCH_MODE_TOOLTIP_TITLE; set => cB_SEARCH_MODE_TOOLTIP_TITLE = value; }
        public static string USER_REG_DATE_TO_SEARCH_TOOLTIP { get => uSER_REG_DATE_TO_SEARCH_TOOLTIP; set => uSER_REG_DATE_TO_SEARCH_TOOLTIP = value; }
        public static string USER_REG_DATE_FROM_SEARCH_TOOLTIP { get => uSER_REG_DATE_FROM_SEARCH_TOOLTIP; set => uSER_REG_DATE_FROM_SEARCH_TOOLTIP = value; }
        public static string LBL_USER_REG_DATE_FROM_TITLE { get => lBL_USER_REG_DATE_FROM_TITLE; set => lBL_USER_REG_DATE_FROM_TITLE = value; }
        public static string LBL_USER_REG_DATE_TO_TITLE { get => lBL_USER_REG_DATE_TO_TITLE; set => lBL_USER_REG_DATE_TO_TITLE = value; }
        public static string DIAGNOSE_SEARCH_TOOLTIP_TITLE { get => dIAGNOSE_SEARCH_TOOLTIP_TITLE; set => dIAGNOSE_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_DIAGNOSE_TITLE { get => lBL_DIAGNOSE_TITLE; set => lBL_DIAGNOSE_TITLE = value; }
        public static string LBL_BALANCE_TITLE { get => lBL_BALANCE_TITLE; set => lBL_BALANCE_TITLE = value; }
        public static string ADDRESS_SEARCH_TOOLTIP_TITLE { get => aDDRESS_SEARCH_TOOLTIP_TITLE; set => aDDRESS_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_ADDRESS_TITLE { get => lBL_ADDRESS_TITLE; set => lBL_ADDRESS_TITLE = value; }
        public static string EMAIL_SEARCH_TOOLTIP_TITLE { get => eMAIL_SEARCH_TOOLTIP_TITLE; set => eMAIL_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_EMAIL_TITLE { get => lBL_EMAIL_TITLE; set => lBL_EMAIL_TITLE = value; }
        public static string PHONE_SEARCH_TOOLTIP_TITLE { get => pHONE_SEARCH_TOOLTIP_TITLE; set => pHONE_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_PHONE_TITLE { get => lBL_PHONE_TITLE; set => lBL_PHONE_TITLE = value; }
        public static string USER_B_DATE_TO_SEARCH_TOOLTIP { get => uSER_B_DATE_TO_SEARCH_TOOLTIP; set => uSER_B_DATE_TO_SEARCH_TOOLTIP = value; }
        public static string USER_B_DATE_FROM_SEARCH_TOOLTIP { get => uSER_B_DATE_FROM_SEARCH_TOOLTIP; set => uSER_B_DATE_FROM_SEARCH_TOOLTIP = value; }
        public static string DISPLAY_NAME_SEARCH_TOOLTIP_TITLE { get => dISPLAY_NAME_SEARCH_TOOLTIP_TITLE; set => dISPLAY_NAME_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_DISPLAY_NAME_TITLE { get => lBL_DISPLAY_NAME_TITLE; set => lBL_DISPLAY_NAME_TITLE = value; }
        public static string PASSWORD_SEARCH_TOOLTIP_TITLE { get => pASSWORD_SEARCH_TOOLTIP_TITLE; set => pASSWORD_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_PASSWORD_TITLE { get => lBL_PASSWORD_TITLE; set => lBL_PASSWORD_TITLE = value; }
        public static string USERNAME_SEARCH_TOOLTIP_TITLE { get => uSERNAME_SEARCH_TOOLTIP_TITLE; set => uSERNAME_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_USERNAME_TITLE { get => lBL_USERNAME_TITLE; set => lBL_USERNAME_TITLE = value; }
        public static string ID_SEARCH_TOOLTIP_TITLE { get => iD_SEARCH_TOOLTIP_TITLE; set => iD_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_ID_TITLE { get => lBL_ID_TITLE; set => lBL_ID_TITLE = value; }
        public static string DGV_USERS_TOOLTIP_TITLE { get => dGV_USERS_TOOLTIP_TITLE; set => dGV_USERS_TOOLTIP_TITLE = value; }
        public static string VENDOR_NAME_SEARCH_TOOLTIP_TITLE { get => vENDOR_NAME_SEARCH_TOOLTIP_TITLE; set => vENDOR_NAME_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_VENDOR_NAME_TITLE { get => lBL_VENDOR_NAME_TITLE; set => lBL_VENDOR_NAME_TITLE = value; }
        public static string DGV_VENDORS_TOOLTIP_TITLE { get => dGV_VENDORS_TOOLTIP_TITLE; set => dGV_VENDORS_TOOLTIP_TITLE = value; }
        public static string VENDOR_NAME_COL_TITLE { get => vENDOR_NAME_COL_TITLE; set => vENDOR_NAME_COL_TITLE = value; }
        public static string VENDOR_ID_COL_TITLE { get => vENDOR_ID_COL_TITLE; set => vENDOR_ID_COL_TITLE = value; }
        public static string VENDORS_TITLE { get => vENDORS_TITLE; set => vENDORS_TITLE = value; }
        public static string VENDORS_TOOLTIP_TITLE { get => vENDORS_TOOLTIP_TITLE; set => vENDORS_TOOLTIP_TITLE = value; }
        public static string LST_PRODUCT_IMAGES_TOOLTIP_TITLE { get => lST_PRODUCT_IMAGES_TOOLTIP_TITLE; set => lST_PRODUCT_IMAGES_TOOLTIP_TITLE = value; }
        public static string PRODUCT_PRICE_SEARCH_TOOLTIP_TITLE { get => pRODUCT_PRICE_SEARCH_TOOLTIP_TITLE; set => pRODUCT_PRICE_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_PRICE_TITLE { get => lBL_PRICE_TITLE; set => lBL_PRICE_TITLE = value; }
        public static string S_LOCATION_SEARCH_TOOLTIP_TITLE { get => s_LOCATION_SEARCH_TOOLTIP_TITLE; set => s_LOCATION_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_USER_B_DATE_FROM_TITLE { get => lBL_USER_B_DATE_FROM_TITLE; set => lBL_USER_B_DATE_FROM_TITLE = value; }
        public static string LBL_USER_B_DATE_TO_TITLE { get => lBL_USER_B_DATE_TO_TITLE; set => lBL_USER_B_DATE_TO_TITLE = value; }
        public static string LBL_S_LOCATION_TITLE { get => lBL_S_LOCATION_TITLE; set => lBL_S_LOCATION_TITLE = value; }
        public static string CB_SELECT_BRAND_SEARCH_TOOLTIP_TITLE { get => cB_SELECT_BRAND_SEARCH_TOOLTIP_TITLE; set => cB_SELECT_BRAND_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_QUANTITY_TITLE { get => lBL_QUANTITY_TITLE; set => lBL_QUANTITY_TITLE = value; }
        public static string QUANTITY_SEARCH_TOOLTIP_TITLE { get => qUANTITY_SEARCH_TOOLTIP_TITLE; set => qUANTITY_SEARCH_TOOLTIP_TITLE = value; }
        public static string PRODUCT_NOTICE_TOOLTIP_TITLE { get => pRODUCT_NOTICE_TOOLTIP_TITLE; set => pRODUCT_NOTICE_TOOLTIP_TITLE = value; }
        public static string PRODUCT_ORDER_NOTICE_TOOLTIP_TITLE { get => pRODUCT_ORDER_NOTICE_TOOLTIP_TITLE; set => pRODUCT_ORDER_NOTICE_TOOLTIP_TITLE = value; }
        public static string ORDER_DELIVERY_NOTICE_TOOLTIP_TITLE { get => oRDER_DELIVERY_NOTICE_TOOLTIP_TITLE; set => oRDER_DELIVERY_NOTICE_TOOLTIP_TITLE = value; }
        public static string ACCOUNT_SETTINGS_NOTICE_TOOLTIP_TITLE { get => aCCOUNT_SETTINGS_NOTICE_TOOLTIP_TITLE; set => aCCOUNT_SETTINGS_NOTICE_TOOLTIP_TITLE = value; }
        public static string LBL_PRODUCT_NOTICE_TITLE { get => lBL_PRODUCT_NOTICE_TITLE; set => lBL_PRODUCT_NOTICE_TITLE = value; }
        public static string LBL_PRODUCT_IMAGE_NOTICE_TITLE { get => lBL_PRODUCT_IMAGE_NOTICE_TITLE; set => lBL_PRODUCT_IMAGE_NOTICE_TITLE = value; }
        public static string LBL_VENDOR_TITLE { get => lBL_VENDOR_TITLE; set => lBL_VENDOR_TITLE = value; }
        public static string CB_SELECT_VENDOR_SEARCH_TOOLTIP_TITLE { get => cB_SELECT_VENDOR_SEARCH_TOOLTIP_TITLE; set => cB_SELECT_VENDOR_SEARCH_TOOLTIP_TITLE = value; }
        public static string PART_NUM_SEARCH_TOOLTIP_TITLE { get => pART_NUM_SEARCH_TOOLTIP_TITLE; set => pART_NUM_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_PART_NUM_TITLE { get => lBL_PART_NUM_TITLE; set => lBL_PART_NUM_TITLE = value; }
        public static string REG_NUM_SEARCH_TOOLTIP_TITLE { get => rEG_NUM_SEARCH_TOOLTIP_TITLE; set => rEG_NUM_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_REG_NUM_TITLE { get => lBL_REG_NUM_TITLE; set => lBL_REG_NUM_TITLE = value; }
        public static string PRODUCT_EXP_DATE_FROM_SEARCH_TOOLTIP_TITLE { get => pRODUCT_EXP_DATE_FROM_SEARCH_TOOLTIP_TITLE; set => pRODUCT_EXP_DATE_FROM_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_PRODUCT_EXP_DATE_FROM_TITLE { get => lBL_PRODUCT_EXP_DATE_FROM_TITLE; set => lBL_PRODUCT_EXP_DATE_FROM_TITLE = value; }
        public static string PRODUCT_EXP_DATE_TO_SEARCH_TOOLTIP_TITLE { get => pRODUCT_EXP_DATE_TO_SEARCH_TOOLTIP_TITLE; set => pRODUCT_EXP_DATE_TO_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_PRODUCT_EXP_DATE_TO_TITLE { get => lBL_PRODUCT_EXP_DATE_TO_TITLE; set => lBL_PRODUCT_EXP_DATE_TO_TITLE = value; }
        public static string PRODUCT_DESCRIPTION_SEARCH_TOOLTIP_TITLE { get => pRODUCT_DESCRIPTION_SEARCH_TOOLTIP_TITLE; set => pRODUCT_DESCRIPTION_SEARCH_TOOLTIP_TITLE = value; }
        public static string PRODUCT_NAME_SEARCH_TOOLTIP_TITLE { get => pRODUCT_NAME_SEARCH_TOOLTIP_TITLE; set => pRODUCT_NAME_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_PRODUCT_DESCRIPTION_TITLE { get => lBL_PRODUCT_DESCRIPTION_TITLE; set => lBL_PRODUCT_DESCRIPTION_TITLE = value; }
        public static string LBL_BRAND_TITLE { get => lBL_BRAND_TITLE; set => lBL_BRAND_TITLE = value; }
        public static string LBL_PRODUCT_NAME_TITLE { get => lBL_PRODUCT_NAME_TITLE; set => lBL_PRODUCT_NAME_TITLE = value; }
        public static string DGV_PRODUCTS_TOOLTIP_TITLE { get => dGV_PRODUCTS_TOOLTIP_TITLE; set => dGV_PRODUCTS_TOOLTIP_TITLE = value; }
        public static string LBL_IMAGES_TITLE { get => lBL_IMAGES_TITLE; set => lBL_IMAGES_TITLE = value; }
        public static string BTN_SEARCH_PRODUCT_IMAGE_TITLE { get => bTN_SEARCH_PRODUCT_IMAGE_TITLE; set => bTN_SEARCH_PRODUCT_IMAGE_TITLE = value; }
        public static string BTN_DELETE_PRODUCT_IMAGE_TITLE { get => bTN_DELETE_PRODUCT_IMAGE_TITLE; set => bTN_DELETE_PRODUCT_IMAGE_TITLE = value; }
        public static string BTN_ADD_EDIT_PRODUCT_IMAGE_TITLE { get => bTN_ADD_EDIT_PRODUCT_IMAGE_TITLE; set => bTN_ADD_EDIT_PRODUCT_IMAGE_TITLE = value; }
        public static string SELECTED_PRODUCT_IMAGE_TOOLTIP_TITLE { get => sELECTED_PRODUCT_IMAGE_TOOLTIP_TITLE; set => sELECTED_PRODUCT_IMAGE_TOOLTIP_TITLE = value; }
        public static string LBL_IMAGE_NAME_TITLE { get => lBL_IMAGE_NAME_TITLE; set => lBL_IMAGE_NAME_TITLE = value; }
        public static string LBL_IMAGE_ID_TITLE { get => lBL_IMAGE_ID_TITLE; set => lBL_IMAGE_ID_TITLE = value; }
        public static string LBL_REFERENCED_ID_TITLE { get => lBL_REFERENCED_ID_TITLE; set => lBL_REFERENCED_ID_TITLE = value; }
        public static string REFERENCED_ID_SEARCH_TOOLTIP_TITLE { get => rEFERENCED_ID_SEARCH_TOOLTIP_TITLE; set => rEFERENCED_ID_SEARCH_TOOLTIP_TITLE = value; }
        public static string IMAGE_NAME_SEARCH_TOOLTIP_TITLE { get => iMAGE_NAME_SEARCH_TOOLTIP_TITLE; set => iMAGE_NAME_SEARCH_TOOLTIP_TITLE = value; }
        public static string PRODUCT_ID_COL_TITLE { get => pRODUCT_ID_COL_TITLE; set => pRODUCT_ID_COL_TITLE = value; }
        public static string BRAND_COL_TITLE { get => bRAND_COL_TITLE; set => bRAND_COL_TITLE = value; }
        public static string VENDOR_COL_TITLE { get => vENDOR_COL_TITLE; set => vENDOR_COL_TITLE = value; }
        public static string PRODUCT_NAME_COL_TITLE { get => pRODUCT_NAME_COL_TITLE; set => pRODUCT_NAME_COL_TITLE = value; }
        public static string PRODUCT_DESCRIPTION_COL_TITLE { get => pRODUCT_DESCRIPTION_COL_TITLE; set => pRODUCT_DESCRIPTION_COL_TITLE = value; }
        public static string PRODUCT_QUANTITY_COL_TITLE { get => pRODUCT_QUANTITY_COL_TITLE; set => pRODUCT_QUANTITY_COL_TITLE = value; }
        public static string PRODUCT_PRICE_COL_TITLE { get => pRODUCT_PRICE_COL_TITLE; set => pRODUCT_PRICE_COL_TITLE = value; }
        public static string PRODUCT_EXP_DATE_COL_TITLE { get => pRODUCT_EXP_DATE_COL_TITLE; set => pRODUCT_EXP_DATE_COL_TITLE = value; }
        public static string PRODUCT_REG_NUM_COL_TITLE { get => pRODUCT_REG_NUM_COL_TITLE; set => pRODUCT_REG_NUM_COL_TITLE = value; }
        public static string PRODUCT_PART_NUM_COL_TITLE { get => pRODUCT_PART_NUM_COL_TITLE; set => pRODUCT_PART_NUM_COL_TITLE = value; }
        public static string PRODUCT_S_LOCATION_COL_TITLE { get => pRODUCT_S_LOCATION_COL_TITLE; set => pRODUCT_S_LOCATION_COL_TITLE = value; }
        public static string PRODUCTS_TITLE { get => pRODUCTS_TITLE; set => pRODUCTS_TITLE = value; }
        public static string PRODUCTS_TOOLTIP_TITLE { get => pRODUCTS_TOOLTIP_TITLE; set => pRODUCTS_TOOLTIP_TITLE = value; }
        public static string DGV_PRODUCT_ORDERS_TOOLTIP_TITLE { get => dGV_PRODUCT_ORDERS_TOOLTIP_TITLE; set => dGV_PRODUCT_ORDERS_TOOLTIP_TITLE = value; }
        public static string PRICE_OVERRIDE_SEARCH_TOOLTIP_TITLE { get => pRICE_OVERRIDE_SEARCH_TOOLTIP_TITLE; set => pRICE_OVERRIDE_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_PRICE_OVERRIDE_TITLE { get => lBL_PRICE_OVERRIDE_TITLE; set => lBL_PRICE_OVERRIDE_TITLE = value; }
        public static string ORDER_REASON_SEARCH_TOOLTIP_TITLE { get => oRDER_REASON_SEARCH_TOOLTIP_TITLE; set => oRDER_REASON_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_ORDER_REASON_TITLE { get => lBL_ORDER_REASON_TITLE; set => lBL_ORDER_REASON_TITLE = value; }
        public static string PO_DATE_ADDED_TO_SEARCH_TOOLTIP_TITLE { get => pO_DATE_ADDED_TO_SEARCH_TOOLTIP_TITLE; set => pO_DATE_ADDED_TO_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_DATE_ADDED_TO_TITLE { get => lBL_DATE_ADDED_TO_TITLE; set => lBL_DATE_ADDED_TO_TITLE = value; }
        public static string PO_DATE_ADDED_FROM_SEARCH_TOOLTIP_TITLE { get => pO_DATE_ADDED_FROM_SEARCH_TOOLTIP_TITLE; set => pO_DATE_ADDED_FROM_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_DATE_ADDED_FROM_TITLE { get => lBL_DATE_ADDED_FROM_TITLE; set => lBL_DATE_ADDED_FROM_TITLE = value; }
        public static string LBL_EMPLOYEE_TITLE { get => lBL_EMPLOYEE_TITLE; set => lBL_EMPLOYEE_TITLE = value; }
        public static string LBL_PRODUCT_TITLE { get => lBL_PRODUCT_TITLE; set => lBL_PRODUCT_TITLE = value; }
        public static string EMPLOYEE_SEARCH_TOOLTIP_TITLE { get => eMPLOYEE_SEARCH_TOOLTIP_TITLE; set => eMPLOYEE_SEARCH_TOOLTIP_TITLE = value; }
        public static string PRODUCT_SEARCH_TOOLTIP_TITLE { get => pRODUCT_SEARCH_TOOLTIP_TITLE; set => pRODUCT_SEARCH_TOOLTIP_TITLE = value; }
        public static string CLIENT_SEARCH_TOOLTIP_TITLE { get => cLIENT_SEARCH_TOOLTIP_TITLE; set => cLIENT_SEARCH_TOOLTIP_TITLE = value; }
        public static string PO_DATE_MODIFIED_FROM_SEARCH_TOOLTIP_TITLE { get => pO_DATE_MODIFIED_FROM_SEARCH_TOOLTIP_TITLE; set => pO_DATE_MODIFIED_FROM_SEARCH_TOOLTIP_TITLE = value; }
        public static string PO_DATE_MODIFIED_TO_SEARCH_TOOLTIP_TITLE { get => pO_DATE_MODIFIED_TO_SEARCH_TOOLTIP_TITLE; set => pO_DATE_MODIFIED_TO_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_PRODUCT_ORDER_NOTICE_TITLE { get => lBL_PRODUCT_ORDER_NOTICE_TITLE; set => lBL_PRODUCT_ORDER_NOTICE_TITLE = value; }
        public static string ORDER_STATUS_SEARCH_TOOLTIP_TITLE { get => oRDER_STATUS_SEARCH_TOOLTIP_TITLE; set => oRDER_STATUS_SEARCH_TOOLTIP_TITLE = value; }
        public static string DESIRED_QUANTITY_SEARCH_TOOLTIP_TITLE { get => dESIRED_QUANTITY_SEARCH_TOOLTIP_TITLE; set => dESIRED_QUANTITY_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_ORDER_STATUS_TITLE { get => lBL_ORDER_STATUS_TITLE; set => lBL_ORDER_STATUS_TITLE = value; }
        public static string LBL_ORDER_STATUS_PENDING { get => lBL_ORDER_STATUS_PENDING; set => lBL_ORDER_STATUS_PENDING = value; }
        public static string LBL_STATUS_PREPAID { get => lBL_STATUS_PREPAID; set => lBL_STATUS_PREPAID = value; }
        public static string LBL_STATUS_PAID_ON_DELIVERY { get => lBL_STATUS_PAID_ON_DELIVERY; set => lBL_STATUS_PAID_ON_DELIVERY = value; }
        public static string LBL_STATUS_DIRECTLY_PAID { get => lBL_STATUS_DIRECTLY_PAID; set => lBL_STATUS_DIRECTLY_PAID = value; }
        public static string LBL_STATUS_GENERATING_INVOICE { get => lBL_STATUS_GENERATING_INVOICE; set => lBL_STATUS_GENERATING_INVOICE = value; }
        public static string LBL_STATUS_GENERATING_REPORT { get => lBL_STATUS_GENERATING_REPORT; set => lBL_STATUS_GENERATING_REPORT = value; }
        public static string LBL_ORDER_STATUS_PROCESSING { get => lBL_ORDER_STATUS_PROCESSING; set => lBL_ORDER_STATUS_PROCESSING = value; }
        public static string LBL_ORDER_STATUS_CANCELLED { get => lBL_ORDER_STATUS_CANCELLED; set => lBL_ORDER_STATUS_CANCELLED = value; }
        public static string LBL_ORDER_STATUS_RETURNED { get => lBL_ORDER_STATUS_RETURNED; set => lBL_ORDER_STATUS_RETURNED = value; }
        public static string LBL_ORDER_STATUS_COMPLETED { get => lBL_ORDER_STATUS_COMPLETED; set => lBL_ORDER_STATUS_COMPLETED = value; }
        public static string LBL_DATE_MODIFIED_TO_TITLE { get => lBL_DATE_MODIFIED_TO_TITLE; set => lBL_DATE_MODIFIED_TO_TITLE = value; }
        public static string LBL_DATE_MODIFIED_FROM_TITLE { get => lBL_DATE_MODIFIED_FROM_TITLE; set => lBL_DATE_MODIFIED_FROM_TITLE = value; }
        public static string LBL_CLIENT_TITLE { get => lBL_CLIENT_TITLE; set => lBL_CLIENT_TITLE = value; }
        public static string LBL_DESIRED_QUANTITY_TITLE { get => lBL_DESIRED_QUANTITY_TITLE; set => lBL_DESIRED_QUANTITY_TITLE = value; }
        public static string ORDER_ID_COL_TITLE { get => oRDER_ID_COL_TITLE; set => oRDER_ID_COL_TITLE = value; }
        public static string PRODUCT_COL_TITLE { get => pRODUCT_COL_TITLE; set => pRODUCT_COL_TITLE = value; }
        public static string DESIRED_QUANTITY_COL_TITLE { get => dESIRED_QUANTITY_COL_TITLE; set => dESIRED_QUANTITY_COL_TITLE = value; }
        public static string ORDER_PRICE_COL_TITLE { get => oRDER_PRICE_COL_TITLE; set => oRDER_PRICE_COL_TITLE = value; }
        public static string EMPLOYEE_COL_TITLE { get => eMPLOYEE_COL_TITLE; set => eMPLOYEE_COL_TITLE = value; }
        public static string CLIENT_COL_TITLE { get => cLIENT_COL_TITLE; set => cLIENT_COL_TITLE = value; }
        public static string DATE_ADDED_COL_TITLE { get => dATE_ADDED_COL_TITLE; set => dATE_ADDED_COL_TITLE = value; }
        public static string DATE_MODIFIED_COL_TITLE { get => dATE_MODIFIED_COL_TITLE; set => dATE_MODIFIED_COL_TITLE = value; }
        public static string ORDER_STATUS_COL_TITLE { get => oRDER_STATUS_COL_TITLE; set => oRDER_STATUS_COL_TITLE = value; }
        public static string ORDER_REASON_COL_TITLE { get => oRDER_REASON_COL_TITLE; set => oRDER_REASON_COL_TITLE = value; }
        public static string PRODUCT_ORDERS_TITLE { get => pRODUCT_ORDERS_TITLE; set => pRODUCT_ORDERS_TITLE = value; }
        public static string PRODUCT_ORDERS_TOOLTIP_TITLE { get => pRODUCT_ORDERS_TOOLTIP_TITLE; set => pRODUCT_ORDERS_TOOLTIP_TITLE = value; }
        public static string BRAND_NAME_SEARCH_TOOLTIP_TITLE { get => bRAND_NAME_SEARCH_TOOLTIP_TITLE; set => bRAND_NAME_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_BRAND_NAME_TITLE { get => lBL_BRAND_NAME_TITLE; set => lBL_BRAND_NAME_TITLE = value; }
        public static string DGV_PRODUCT_BRANDS_TOOLTIP_TITLE { get => dGV_PRODUCT_BRANDS_TOOLTIP_TITLE; set => dGV_PRODUCT_BRANDS_TOOLTIP_TITLE = value; }
        public static string BRAND_NAME_COL_TITLE { get => bRAND_NAME_COL_TITLE; set => bRAND_NAME_COL_TITLE = value; }
        public static string BRAND_ID_COL_TITLE { get => bRAND_ID_COL_TITLE; set => bRAND_ID_COL_TITLE = value; }
        public static string PRODUCT_BRANDS_TITLE { get => pRODUCT_BRANDS_TITLE; set => pRODUCT_BRANDS_TITLE = value; }
        public static string PRODUCT_BRANDS_TOOLTIP_TITLE { get => pRODUCT_BRANDS_TOOLTIP_TITLE; set => pRODUCT_BRANDS_TOOLTIP_TITLE = value; }
        public static string METHOD_NAME_SEARCH_TOOLTIP_TITLE { get => mETHOD_NAME_SEARCH_TOOLTIP_TITLE; set => mETHOD_NAME_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_METHOD_NAME_TITLE { get => lBL_METHOD_NAME_TITLE; set => lBL_METHOD_NAME_TITLE = value; }
        public static string DGV_PAYMENT_METHODS_TOOLTIP_TITLE { get => dGV_PAYMENT_METHODS_TOOLTIP_TITLE; set => dGV_PAYMENT_METHODS_TOOLTIP_TITLE = value; }
        public static string METHOD_ID_COL_TITLE { get => mETHOD_ID_COL_TITLE; set => mETHOD_ID_COL_TITLE = value; }
        public static string METHOD_NAME_COL_TITLE { get => mETHOD_NAME_COL_TITLE; set => mETHOD_NAME_COL_TITLE = value; }
        public static string PAYMENT_METHODS_TITLE { get => pAYMENT_METHODS_TITLE; set => pAYMENT_METHODS_TITLE = value; }
        public static string PAYMENT_METHODS_TOOLTIP_TITLE { get => pAYMENT_METHODS_TOOLTIP_TITLE; set => pAYMENT_METHODS_TOOLTIP_TITLE = value; }
        public static string DGV_ORDER_DELIVERIES_TOOLTIP_TITLE { get => dGV_ORDER_DELIVERIES_TOOLTIP_TITLE; set => dGV_ORDER_DELIVERIES_TOOLTIP_TITLE = value; }
        public static string TOTAL_PRICE_SEARCH_TOOLTIP_TITLE { get => tOTAL_PRICE_SEARCH_TOOLTIP_TITLE; set => tOTAL_PRICE_SEARCH_TOOLTIP_TITLE = value; }
        public static string CARGO_ID_SEARCH_TOOLTIP_TITLE { get => cARGO_ID_SEARCH_TOOLTIP_TITLE; set => cARGO_ID_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_CARGO_ID_TITLE { get => lBL_CARGO_ID_TITLE; set => lBL_CARGO_ID_TITLE = value; }
        public static string LBL_DELIVERY_STATUS_TITLE { get => lBL_DELIVERY_STATUS_TITLE; set => lBL_DELIVERY_STATUS_TITLE = value; }
        public static string LBL_DELIVERY_STATUS_PENDING { get => lBL_DELIVERY_STATUS_PENDING; set => lBL_DELIVERY_STATUS_PENDING = value; }
        public static string LBL_DELIVERY_STATUS_ON_THE_MOVE { get => lBL_DELIVERY_STATUS_ON_THE_MOVE; set => lBL_DELIVERY_STATUS_ON_THE_MOVE = value; }
        public static string LBL_DELIVERY_STATUS_CANCELLED { get => lBL_DELIVERY_STATUS_CANCELLED; set => lBL_DELIVERY_STATUS_CANCELLED = value; }
        public static string LBL_DELIVERY_STATUS_RETURNED { get => lBL_DELIVERY_STATUS_RETURNED; set => lBL_DELIVERY_STATUS_RETURNED = value; }
        public static string LBL_DELIVERY_STATUS_COMPLETED { get => lBL_DELIVERY_STATUS_COMPLETED; set => lBL_DELIVERY_STATUS_COMPLETED = value; }
        public static string DELIVERY_STATUS_SEARCH_TOOLTIP_TITLE { get => dELIVERY_STATUS_SEARCH_TOOLTIP_TITLE; set => dELIVERY_STATUS_SEARCH_TOOLTIP_TITLE = value; }
        public static string ORDER_DELIVERY_NOTICE_TITLE { get => oRDER_DELIVERY_NOTICE_TITLE; set => oRDER_DELIVERY_NOTICE_TITLE = value; }
        public static string OD_DATE_MODIFIED_TO_SEARCH_TOOLTIP_TITLE { get => oD_DATE_MODIFIED_TO_SEARCH_TOOLTIP_TITLE; set => oD_DATE_MODIFIED_TO_SEARCH_TOOLTIP_TITLE = value; }
        public static string OD_DATE_MODIFIED_FROM_SEARCH_TOOLTIP_TITLE { get => oD_DATE_MODIFIED_FROM_SEARCH_TOOLTIP_TITLE; set => oD_DATE_MODIFIED_FROM_SEARCH_TOOLTIP_TITLE = value; }
        public static string PAYMENT_METHOD_SEARCH_TOOLTIP_TITLE { get => pAYMENT_METHOD_SEARCH_TOOLTIP_TITLE; set => pAYMENT_METHOD_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_PAYMENT_METHOD_TITLE { get => lBL_PAYMENT_METHOD_TITLE; set => lBL_PAYMENT_METHOD_TITLE = value; }
        public static string PRODUCT_ORDER_SEARCH_TOOLTIP_TITLE { get => pRODUCT_ORDER_SEARCH_TOOLTIP_TITLE; set => pRODUCT_ORDER_SEARCH_TOOLTIP_TITLE = value; }
        public static string DELIVERY_SERVICE_SEARCH_TOOLTIP_TITLE { get => dELIVERY_SERVICE_SEARCH_TOOLTIP_TITLE; set => dELIVERY_SERVICE_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_TOTAL_PRICE_TITLE { get => lBL_TOTAL_PRICE_TITLE; set => lBL_TOTAL_PRICE_TITLE = value; }
        public static string DELIVERY_REASON_SEARCH_TOOLTIP_TITLE { get => dELIVERY_REASON_SEARCH_TOOLTIP_TITLE; set => dELIVERY_REASON_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_DELIVERY_REASON_TITLE { get => lBL_DELIVERY_REASON_TITLE; set => lBL_DELIVERY_REASON_TITLE = value; }
        public static string OD_DATE_ADDED_TO_SEARCH_TOOLTIP_TITLE { get => oD_DATE_ADDED_TO_SEARCH_TOOLTIP_TITLE; set => oD_DATE_ADDED_TO_SEARCH_TOOLTIP_TITLE = value; }
        public static string OD_DATE_ADDED_FROM_SEARCH_TOOLTIP_TITLE { get => oD_DATE_ADDED_FROM_SEARCH_TOOLTIP_TITLE; set => oD_DATE_ADDED_FROM_SEARCH_TOOLTIP_TITLE = value; }
        public static string LBL_DELIVERY_SERVICE_TITLE { get => lBL_DELIVERY_SERVICE_TITLE; set => lBL_DELIVERY_SERVICE_TITLE = value; }
        public static string LBL_PRODUCT_ORDER_TITLE { get => lBL_PRODUCT_ORDER_TITLE; set => lBL_PRODUCT_ORDER_TITLE = value; }
        public static string DELIVERY_ID_COL_TITLE { get => dELIVERY_ID_COL_TITLE; set => dELIVERY_ID_COL_TITLE = value; }
        public static string PRODUCT_ORDER_COL_TITLE { get => pRODUCT_ORDER_COL_TITLE; set => pRODUCT_ORDER_COL_TITLE = value; }
        public static string TOTAL_PRICE_COL_TITLE { get => tOTAL_PRICE_COL_TITLE; set => tOTAL_PRICE_COL_TITLE = value; }
        public static string DELIVERY_SERVICE_COL_TITLE { get => dELIVERY_SERVICE_COL_TITLE; set => dELIVERY_SERVICE_COL_TITLE = value; }
        public static string PAYMENT_METHOD_COL_TITLE { get => pAYMENT_METHOD_COL_TITLE; set => pAYMENT_METHOD_COL_TITLE = value; }
        public static string CARGO_ID_COL_TITLE { get => cARGO_ID_COL_TITLE; set => cARGO_ID_COL_TITLE = value; }
        public static string DELIVERY_STATUS_COL_TITLE { get => dELIVERY_STATUS_COL_TITLE; set => dELIVERY_STATUS_COL_TITLE = value; }
        public static string DELIVERY_REASON_COL_TITLE { get => dELIVERY_REASON_COL_TITLE; set => dELIVERY_REASON_COL_TITLE = value; }
        public static string ORDER_DELIVERIES_TITLE { get => oRDER_DELIVERIES_TITLE; set => oRDER_DELIVERIES_TITLE = value; }
        public static string ORDER_DELIVERIES_TOOLTIP_TITLE { get => oRDER_DELIVERIES_TOOLTIP_TITLE; set => oRDER_DELIVERIES_TOOLTIP_TITLE = value; }

        public GLOBAL_RESOURCES()
        {
            ResourceManager manager = Resources.ResourceManager;
            if (instance == null)
            {
                instance = this;
            }
            RefreshSettings();
            Application.CurrentCulture = CultureInfo.GetCultureInfo(GLOBAL_RESOURCES.CURRENT_CULTURE);
            UpdateCurrentCultureResources();
        }

        private void InvokeCultureInfoChangedEvent(CultureInfo culture)
        {
            if(CultureInfoChanged != null)
            {
                CultureInfoChanged(this, culture);
            }
        }



        public static void RefreshSettings()
        {
            DOMAIN_ADDRESS = ConfigurationManager.AppSettings["domain"];
            DB_NAME = ConfigurationManager.AppSettings["dbname"];
            DB_USER = ConfigurationManager.AppSettings["dbuser"];
            DB_PASSWORD = ConfigurationManager.AppSettings["dbpassword"];
            COMPANY_NAME = ConfigurationManager.AppSettings["company_name"];
            CURRENT_CULTURE = ConfigurationManager.AppSettings["current_culture"];
            SAVED_LOGINS_DIRECTORY = (ConfigurationManager.AppSettings["saved_logins_directory"] != null &&
               Directory.Exists(Path.GetFullPath(ConfigurationManager.AppSettings["saved_logins_directory"]))) ?
               Path.GetFullPath(ConfigurationManager.AppSettings["saved_logins_directory"]) :
               Path.GetFullPath($"{Application.StartupPath}/{ConfigurationManager.AppSettings["saved_logins_directory"]}/");
            REPORT_DIRECTORY = (ConfigurationManager.AppSettings["report_directory"] != null &&
                Directory.Exists(Path.GetFullPath(ConfigurationManager.AppSettings["report_directory"]))) ?
                Path.GetFullPath(ConfigurationManager.AppSettings["report_directory"]) :
                Path.GetFullPath($"{Application.StartupPath}/{ConfigurationManager.AppSettings["report_directory"]}/");
            EMPLOYEE_REPORT_NAME = ConfigurationManager.AppSettings["emp_report_name"];
            CLIENT_REPORT_NAME = ConfigurationManager.AppSettings["cl_report_name"];
            PRODUCT_BRAND_REPORT_NAME = ConfigurationManager.AppSettings["pb_report_name"];
            PRODUCT_VENDOR_REPORT_NAME = ConfigurationManager.AppSettings["pv_report_name"];
            PAYMENT_METHOD_REPORT_NAME = ConfigurationManager.AppSettings["pm_report_name"];
            DELIVERY_SERVICE_REPORT_NAME = ConfigurationManager.AppSettings["ds_report_name"];
            PRODUCT_REPORT_NAME = ConfigurationManager.AppSettings["p_report_name"];
            PRODUCT_ORDER_REPORT_NAME = ConfigurationManager.AppSettings["po_report_name"];
            PRODUCT_ORDER_INVOICE_REPORT_NAME = ConfigurationManager.AppSettings["poi_report_name"];
            ORDER_DELIVERY_REPORT_NAME = ConfigurationManager.AppSettings["od_report_name"];
            ORDER_DELIVERY_INVOICE_REPORT_NAME = ConfigurationManager.AppSettings["odi_report_name"];
        }

        public static void UpdateCurrentCultureResources()
        {
            ResourceManager manager = Resources.ResourceManager;
            CRITICAL_ERROR_MESSAGE = manager.GetString("CriticalErrorMessage", CultureInfo.CurrentCulture);
            CRITICAL_ERROR_INNER_EXCEPTION_DETAILS = manager.GetString("CriticalErrorInnerExceptionDetails",CultureInfo.CurrentCulture);
            STACK_TRACE_MESSAGE = manager.GetString("StackTraceMessage", CultureInfo.CurrentCulture);
            CRITICAL_ERROR_TITLE = manager.GetString("CriticalErrorTitle", CultureInfo.CurrentCulture);
            CLOSE_PROMPT = manager.GetString("ClosePrompt", CultureInfo.CurrentCulture);
            CLOSE_PROMPT_TITLE = manager.GetString("ClosePromptTitle", CultureInfo.CurrentCulture);
            BULK_OPERATIONS_TITLE = manager.GetString("BulkOperationsTitle", CultureInfo.CurrentCulture);
            APPLICATION_INSTANCE_ERROR_MESSAGE = manager.GetString("ApplicationInstanceErrorMessage", CultureInfo.CurrentCulture);
            CONNECTION_SUCCESSFUL_MESSAGE = manager.GetString("ConnectionSuccessfulMessage", CultureInfo.CurrentCulture);
            CONNECTION_SUCCESSFUL_LOGIN_MESSAGE = manager.GetString("ConnectionSuccessfulLoginMessage", CultureInfo.CurrentCulture); 
            CONNECTION_FAILED_MESSAGE = manager.GetString("ConnectionFailedMessage", CultureInfo.CurrentCulture);
            CONNECTION_FAILED_AFTER_RETRY_MESSAGE = manager.GetString("ConnectionFailedAfterRetryMessage", CultureInfo.CurrentCulture);
            CONNECTION_FAILED_LOGIN_MESSAGE = manager.GetString("ConnectionFailedLoginMessage", CultureInfo.CurrentCulture);
            BULK_OPERATION_QUESTION = manager.GetString("BulkOperationQuestion", CultureInfo.CurrentCulture);
            AUTHORISATION_ERROR_NO_LOGIN_MESSAGE = manager.GetString("AuthorisationErrorNoLoginMessage",CultureInfo.CurrentCulture);
            AUTHORISATION_ERROR_CANCELLED_LOGIN_MESSAGE = manager.GetString("AuthorisationErrorCancelledLoginMessage", CultureInfo.CurrentCulture);
            AUTHORISATION_ERROR_CLIENT_LOGIN_MESSAGE = manager.GetString("AuthorisationErrorClientLoginMessage", CultureInfo.CurrentCulture);
            AUTHORISATION_ERROR_SYSADMIN_BREACH_MESSAGE = manager.GetString("AuthorisationErrorSysAdminBreachMessage", CultureInfo.CurrentCulture);
            AUTHORISATION_APPCONF_LOGIN_FOUND_MESSAGE = manager.GetString("AuthorisationAppConfLoginFoundMessage",CultureInfo.CurrentCulture);
            AUTHORISATION_APPCONF_LOGIN_NOT_FOUND_MESSAGE = manager.GetString("AuthorisationAppConfLoginNotFoundMessage", CultureInfo.CurrentCulture);
            AUTHORISATION_LOGIN_EMPTY_INPUT_MESSAGE = manager.GetString("AuthorisationLoginEmptyInputMessage",CultureInfo.CurrentCulture);
            AUTHORISATION_LOGIN_EMPTY_INPUT_MESSAGE = manager.GetString("AuthorisationLoginInvalidInputMessage",CultureInfo.CurrentCulture);
            AUTHORISATION_ADD_LOGIN_INVALID_RESULTS_MESSAGE = manager.GetString("AuthorisationAddLoginInvalidResultsMessage", CultureInfo.CurrentCulture);
            AUTHORISATION_LOGIN_NO_CONNECTION_MESSAGE = manager.GetString("AuthorisationLoginNoConnectionMessage", CultureInfo.CurrentCulture);
            AUTHORISATION_LOGIN_FILESYSTEM_LOAD_ERROR_MESSAGE = manager.GetString("AuthorisationLoginFilesystemLoadErrorMessage", CultureInfo.CurrentCulture);
            AUTHORISATION_LOGIN_EMPLOYEE_NOTICE = manager.GetString("AuthorisationLoginEmployeeNotice", CultureInfo.CurrentCulture);
            AUTHORISATION_LOGIN_ADMIN_NOTICE = manager.GetString("AuthorisationLoginAdminNotice", CultureInfo.CurrentCulture);
            TEST_TITLE = manager.GetString("TestTitle", CultureInfo.CurrentCulture);
            LOGIN_TITLE = manager.GetString("LoginTitle", CultureInfo.CurrentCulture);
            CURRENT_HOST_TITLE = manager.GetString("CurrentHostTitle", CultureInfo.CurrentCulture);
            CURRENT_OPERATOR_TITLE = manager.GetString("CurrentOperatorTitle", CultureInfo.CurrentCulture);
            USER_ACCESS_TITLE = manager.GetString("UserAccessTitle", CultureInfo.CurrentCulture);
            ACCOUNT_SETTINGS_TITLE = manager.GetString("AccountSettingsTitle",CultureInfo.CurrentCulture);
            APPLICATION_SETTINGS_TITLE = manager.GetString("ApplicationSettingsTitle", CultureInfo.CurrentCulture);
            ACCOUNT_SETTINGS_PROFILE_PIC_SELECT_TITLE = manager.GetString("AccountSettingsProfilePicSelectTitle", CultureInfo.CurrentCulture);
            APPLICATION_SETTINGS_LOGINS_FOLDER_SELECT_TITLE = manager.GetString("ApplicationSettingsLoginsFolderSelectTitle", CultureInfo.CurrentCulture);
            APPLICATION_SETTINGS_REPORTS_FOLDER_SELECT_TITLE = manager.GetString("ApplicationSettingsReportsFolderSelectTitle", CultureInfo.CurrentCulture);
            IMAGE_BIN_CONVERTER_CONVERT_IMAGE_TITLE = manager.GetString("ImageBinConverterConvertImageTitle", CultureInfo.CurrentCulture);
            ABOUT_TITLE = manager.GetString("AboutTitle", CultureInfo.CurrentCulture);
            VERSION_TITLE = manager.GetString("VersionTitle", CultureInfo.CurrentCulture);
            ASSEMBLY_PRODUCT_NAME = manager.GetString("AssemblyProductName", CultureInfo.CurrentCulture);
            ASSEMBLY_TITLE = manager.GetString("AssemblyTitle", CultureInfo.CurrentCulture);
            WARNING_TITLE = manager.GetString("WarningTitle", CultureInfo.CurrentCulture);
            NEW_ORDER_TITLE = manager.GetString("NewOrderTitle", CultureInfo.CurrentCulture);
            REPORT_GENERATION_TITLE = manager.GetString("ReportGenerationTitle", CultureInfo.CurrentCulture);
            IMAGE_UPLOAD_FOR_OPERATION_TITLE = manager.GetString("ImageUploadForOperationTitle", CultureInfo.CurrentCulture);
            USERS_TITLE = manager.GetString("UsersTitle", CultureInfo.CurrentCulture);
            USERS_TOOLTIP_TITLE = manager.GetString("UsersTooltipTitle", CultureInfo.CurrentCulture);
            VENDORS_TITLE = manager.GetString("VendorsTitle", CultureInfo.CurrentCulture);
            VENDORS_TOOLTIP_TITLE = manager.GetString("VendorsTooltipTitle", CultureInfo.CurrentCulture);
            PRODUCTS_TITLE = manager.GetString("ProductsTitle", CultureInfo.CurrentCulture); 
            PRODUCTS_TOOLTIP_TITLE = manager.GetString("ProductsTooltipTitle", CultureInfo.CurrentCulture);
            PRODUCT_ORDERS_TITLE = manager.GetString("ProductOrdersTitle", CultureInfo.CurrentCulture);
            PRODUCT_ORDERS_TOOLTIP_TITLE = manager.GetString("ProductOrdersTooltipTitle", CultureInfo.CurrentCulture);
            PRODUCT_BRANDS_TITLE = manager.GetString("ProductBrandsTitle", CultureInfo.CurrentCulture);
            PRODUCT_BRANDS_TOOLTIP_TITLE = manager.GetString("ProductBrandsTooltipTitle", CultureInfo.CurrentCulture);
            ROLE_COL_TITLE = manager.GetString("RoleColTitle", CultureInfo.CurrentCulture);
            LBL_ROLE_ADMIN = manager.GetString("LblRoleAdmin", CultureInfo.CurrentCulture);
            LBL_ROLE_EMPLOYEE = manager.GetString("LblRoleEmployee", CultureInfo.CurrentCulture);
            LBL_ROLE_CLIENT = manager.GetString("LblRoleClient", CultureInfo.CurrentCulture);
            ROLE_SEARCH_TOOLTIP_TITLE = manager.GetString("RoleSearchTooltip", CultureInfo.CurrentCulture);
            LBL_ROLE_TITLE = manager.GetString("LblRoleTitle", CultureInfo.CurrentCulture);
            REGISTER_DATE_COL_TITLE = manager.GetString("RegisterDateColTitle", CultureInfo.CurrentCulture);
            DIAGNOSE_COL_TITLE = manager.GetString("DiagnoseColTitle", CultureInfo.CurrentCulture);
            BALANCE_COL_TITLE = manager.GetString("BalanceColTitle", CultureInfo.CurrentCulture);
            PROFILE_PIC_COL_TITLE = manager.GetString("ProfilePicColTitle", CultureInfo.CurrentCulture);
            ADDRESS_COL_TITLE = manager.GetString("AddressColTitle", CultureInfo.CurrentCulture);
            EMAIL_COL_TITLE = manager.GetString("EmailColTitle", CultureInfo.CurrentCulture);
            PHONE_COL_TITLE = manager.GetString("PhoneColTitle", CultureInfo.CurrentCulture);
            BIRTH_DATE_COL_TITLE = manager.GetString("BirthDateColTitle", CultureInfo.CurrentCulture);
            DISPLAY_NAME_COL_TITLE = manager.GetString("DisplayNameColTitle", CultureInfo.CurrentCulture);
            PASSWORD_COL_TITLE = manager.GetString("PasswordColTitle", CultureInfo.CurrentCulture);
            USER_NAME_COL_TITLE = manager.GetString("UserNameColTitle", CultureInfo.CurrentCulture);
            USER_ID_COL_TITLE = manager.GetString("UserIDColTitle", CultureInfo.CurrentCulture);
            VENDOR_NAME_COL_TITLE = manager.GetString("VendorNameColTitle", CultureInfo.CurrentCulture);
            VENDOR_ID_COL_TITLE = manager.GetString("VendorIDColTitle", CultureInfo.CurrentCulture);
            PRODUCT_ID_COL_TITLE = manager.GetString("ProductIDColTitle", CultureInfo.CurrentCulture);
            BRAND_COL_TITLE = manager.GetString("BrandColTitle", CultureInfo.CurrentCulture);
            VENDOR_COL_TITLE = manager.GetString("VendorColTitle", CultureInfo.CurrentCulture);
            PRODUCT_NAME_COL_TITLE = manager.GetString("ProductNameColTitle", CultureInfo.CurrentCulture);
            PRODUCT_DESCRIPTION_COL_TITLE = manager.GetString("ProductDescriptionColTitle", CultureInfo.CurrentCulture);
            PRODUCT_QUANTITY_COL_TITLE = manager.GetString("ProductQuantityColTitle", CultureInfo.CurrentCulture);
            PRODUCT_PRICE_COL_TITLE = manager.GetString("ProductPriceColTitle", CultureInfo.CurrentCulture);
            PRODUCT_EXP_DATE_COL_TITLE = manager.GetString("ProductExpDateColTitle", CultureInfo.CurrentCulture);
            PRODUCT_REG_NUM_COL_TITLE = manager.GetString("ProductRegNumColTitle", CultureInfo.CurrentCulture);
            PRODUCT_PART_NUM_COL_TITLE = manager.GetString("ProductPartNumColTitle", CultureInfo.CurrentCulture);
            PRODUCT_S_LOCATION_COL_TITLE = manager.GetString("ProductSLocationColTitle", CultureInfo.CurrentCulture);
            ORDER_ID_COL_TITLE = manager.GetString("OrderIDColTitle", CultureInfo.CurrentCulture);
            PRODUCT_COL_TITLE = manager.GetString("ProductColTitle", CultureInfo.CurrentCulture);
            DESIRED_QUANTITY_COL_TITLE = manager.GetString("DesiredQuantityColTitle", CultureInfo.CurrentCulture);
            ORDER_PRICE_COL_TITLE = manager.GetString("OrderPriceColTitle", CultureInfo.CurrentCulture);
            EMPLOYEE_COL_TITLE = manager.GetString("EmployeeColTitle", CultureInfo.CurrentCulture);
            CLIENT_COL_TITLE = manager.GetString("ClientColTitle", CultureInfo.CurrentCulture);
            DATE_ADDED_COL_TITLE = manager.GetString("DateAddedColTitle", CultureInfo.CurrentCulture);
            DATE_MODIFIED_COL_TITLE = manager.GetString("DateModifiedColTitle", CultureInfo.CurrentCulture);
            ORDER_STATUS_COL_TITLE = manager.GetString("OrderStatusColTitle", CultureInfo.CurrentCulture);
            ORDER_REASON_COL_TITLE = manager.GetString("OrderReasonColTitle", CultureInfo.CurrentCulture);
            HELP_TITLE = manager.GetString("HelpTooltipTitle", CultureInfo.CurrentCulture);
            USER_NOTICE_TOOLTIP_TITLE = manager.GetString("UserNoticeTooltipTitle", CultureInfo.CurrentCulture);
            LBL_USER_NOTICE_TITLE = manager.GetString("LblUserNoticeTitle", CultureInfo.CurrentCulture);
            BTN_GENERATE_REPORT_TITLE = manager.GetString("BtnGenerateReportTitle", CultureInfo.CurrentCulture);
            BTN_GENERATE_REPORT_TOOLTIP_TITLE = manager.GetString("BtnGenerateReportTooltip", CultureInfo.CurrentCulture);
            BALANCE_SEARCH_TOOLTIP_TITLE = manager.GetString("BalanceSearchTooltipTitle", CultureInfo.CurrentCulture);
            BTN_DELETE_TITLE = manager.GetString("BtnDeleteTitle", CultureInfo.CurrentCulture);
            BTN_DELETE_TOOLTIP_TITLE = manager.GetString("BtnDeleteTooltipTitle", CultureInfo.CurrentCulture);
            BTN_ADD_EDIT_TITLE = manager.GetString("BtnAddEditTitle", CultureInfo.CurrentCulture);
            BTN_ADD_EDIT_TOOLTIP_TITLE = manager.GetString("BtnAddEditTooltipTitle", CultureInfo.CurrentCulture);
            LBL_SEARCH_MODE_TITLE = manager.GetString("LblSearchModeTitle", CultureInfo.CurrentCulture);
            LBL_SEARCH_MODE_NONE = manager.GetString("LblSearchModeNone", CultureInfo.CurrentCulture);
            LBL_SEARCH_MODE_SINGLE = manager.GetString("LblSearchModeSingle", CultureInfo.CurrentCulture);
            LBL_SEARCH_MODE_MULTIPLE = manager.GetString("LblSearchModeMultiple", CultureInfo.CurrentCulture);
            LBL_SEARCH_MODE_ALL = manager.GetString("LblSearchModeAll", CultureInfo.CurrentCulture);
            CB_SEARCH_MODE_TOOLTIP_TITLE = manager.GetString("CbSearchModeTooltipTitle", CultureInfo.CurrentCulture);
            USER_REG_DATE_TO_SEARCH_TOOLTIP = manager.GetString("UserRegDateToSearchTooltip", CultureInfo.CurrentCulture);
            USER_REG_DATE_FROM_SEARCH_TOOLTIP = manager.GetString("UserRegDateFromSearchTooltip", CultureInfo.CurrentCulture);
            USER_B_DATE_TO_SEARCH_TOOLTIP = manager.GetString("UserBDateToSearchTooltip", CultureInfo.CurrentCulture);
            USER_B_DATE_FROM_SEARCH_TOOLTIP = manager.GetString("UserBDateFromSearchTooltip", CultureInfo.CurrentCulture);
            DIAGNOSE_SEARCH_TOOLTIP_TITLE = manager.GetString("DiagnoseSearchTooltip", CultureInfo.CurrentCulture);
            ADDRESS_SEARCH_TOOLTIP_TITLE = manager.GetString("AddressSearchTooltip", CultureInfo.CurrentCulture);
            EMAIL_SEARCH_TOOLTIP_TITLE = manager.GetString("EmailSearchTooltip", CultureInfo.CurrentCulture);
            PHONE_SEARCH_TOOLTIP_TITLE = manager.GetString("PhoneSearchTooltip", CultureInfo.CurrentCulture);
            DISPLAY_NAME_SEARCH_TOOLTIP_TITLE = manager.GetString("DisplayNameSearchTooltip", CultureInfo.CurrentCulture);
            PASSWORD_SEARCH_TOOLTIP_TITLE = manager.GetString("PasswordSearchTooltip", CultureInfo.CurrentCulture);
            USERNAME_SEARCH_TOOLTIP_TITLE = manager.GetString("UsernameSearchTooltip", CultureInfo.CurrentCulture);
            VENDOR_NAME_SEARCH_TOOLTIP_TITLE = manager.GetString("VendorNameSearchTooltipTitle", CultureInfo.CurrentCulture);
            PRODUCT_PRICE_SEARCH_TOOLTIP_TITLE = manager.GetString("ProductPriceSearchTooltipTitle", CultureInfo.CurrentCulture);
            PRODUCT_NAME_SEARCH_TOOLTIP_TITLE = manager.GetString("ProductNameSearchTooltipTitle", CultureInfo.CurrentCulture);
            IMAGE_NAME_SEARCH_TOOLTIP_TITLE = manager.GetString("ImageNameSearchTooltipTitle", CultureInfo.CurrentCulture);
            PRICE_OVERRIDE_SEARCH_TOOLTIP_TITLE = manager.GetString("PriceOverrideSearchTooltipTitle", CultureInfo.CurrentCulture);
            ORDER_REASON_SEARCH_TOOLTIP_TITLE = manager.GetString("OrderReasonSearchTooltipTitle", CultureInfo.CurrentCulture);
            PO_DATE_ADDED_TO_SEARCH_TOOLTIP_TITLE = manager.GetString("PODateAddedToSearchTooltipTitle", CultureInfo.CurrentCulture);
            PO_DATE_ADDED_FROM_SEARCH_TOOLTIP_TITLE = manager.GetString("PODateAddedFromSearchTooltipTitle", CultureInfo.CurrentCulture);
            PO_DATE_MODIFIED_FROM_SEARCH_TOOLTIP_TITLE = manager.GetString("PODateModifiedFromSearchTooltipTitle", CultureInfo.CurrentCulture);
            PO_DATE_MODIFIED_TO_SEARCH_TOOLTIP_TITLE = manager.GetString("PODateModifiedToSearchTooltipTitle", CultureInfo.CurrentCulture);
            ORDER_STATUS_SEARCH_TOOLTIP_TITLE = manager.GetString("OrderStatusSearchTooltipTitle", CultureInfo.CurrentCulture);
            DESIRED_QUANTITY_SEARCH_TOOLTIP_TITLE = manager.GetString("DesiredQuantitySearchTooltipTitle", CultureInfo.CurrentCulture);
            EMPLOYEE_SEARCH_TOOLTIP_TITLE = manager.GetString("EmployeeSearchTooltipTitle", CultureInfo.CurrentCulture);
            PRODUCT_SEARCH_TOOLTIP_TITLE = manager.GetString("ProductSearchTooltipTitle", CultureInfo.CurrentCulture);
            CLIENT_SEARCH_TOOLTIP_TITLE = manager.GetString("ClientSearchTooltipTitle", CultureInfo.CurrentCulture);
            BRAND_NAME_SEARCH_TOOLTIP_TITLE = manager.GetString("BrandNameSearchTooltipTitle", CultureInfo.CurrentCulture);
            METHOD_NAME_SEARCH_TOOLTIP_TITLE = manager.GetString("MethodNameSearchTooltipTitle", CultureInfo.CurrentCulture);
            BTN_SEARCH_TOOLTIP_TITLE = manager.GetString("BtnSearchTooltipTitle", CultureInfo.CurrentCulture);
            DGV_USERS_TOOLTIP_TITLE = manager.GetString("DgvUsersTooltipTitle", CultureInfo.CurrentCulture);
            ID_SEARCH_TOOLTIP_TITLE = manager.GetString("IDSearchTooltip", CultureInfo.CurrentCulture);
            DGV_VENDORS_TOOLTIP_TITLE = manager.GetString("DgvVendorsTooltipTitle", CultureInfo.CurrentCulture);
            LST_PRODUCT_IMAGES_TOOLTIP_TITLE = manager.GetString("LstProductImagesTooltipTitle", CultureInfo.CurrentCulture);
            S_LOCATION_SEARCH_TOOLTIP_TITLE = manager.GetString("SLocationSearchTooltipTitle", CultureInfo.CurrentCulture);
            PART_NUM_SEARCH_TOOLTIP_TITLE = manager.GetString("PartNumSearchTooltipTitle", CultureInfo.CurrentCulture);
            REG_NUM_SEARCH_TOOLTIP_TITLE = manager.GetString("RegNumSearchTooltipTitle", CultureInfo.CurrentCulture);
            PRODUCT_EXP_DATE_TO_SEARCH_TOOLTIP_TITLE = manager.GetString("ProductExpDateToSearchTooltip", CultureInfo.CurrentCulture);
            PRODUCT_EXP_DATE_FROM_SEARCH_TOOLTIP_TITLE = manager.GetString("ProductExpDateFromSearchTooltip", CultureInfo.CurrentCulture);
            CB_SELECT_BRAND_SEARCH_TOOLTIP_TITLE = manager.GetString("CbSelectBrandSearchTooltipTitle", CultureInfo.CurrentCulture);
            CB_SELECT_VENDOR_SEARCH_TOOLTIP_TITLE = manager.GetString("CbSelectVendorSearchTooltipTitle", CultureInfo.CurrentCulture);
            QUANTITY_SEARCH_TOOLTIP_TITLE = manager.GetString("QuantitySearchTooltipTitle", CultureInfo.CurrentCulture);
            PRODUCT_NOTICE_TOOLTIP_TITLE = manager.GetString("ProductNoticeTooltipTitle", CultureInfo.CurrentCulture);
            PRODUCT_ORDER_NOTICE_TOOLTIP_TITLE = manager.GetString("ProductOrderNoticeTooltipTitle", CultureInfo.CurrentCulture);
            ORDER_DELIVERY_NOTICE_TOOLTIP_TITLE = manager.GetString("OrderDeliveryNoticeTooltipTitle", CultureInfo.CurrentCulture);
            ACCOUNT_SETTINGS_NOTICE_TOOLTIP_TITLE = manager.GetString("AccountSettingsNoticeTooltipTitle", CultureInfo.CurrentCulture);
            LBL_DIAGNOSE_TITLE = manager.GetString("LblDiagnoseTitle", CultureInfo.CurrentCulture);
            LBL_USER_REG_DATE_FROM_TITLE = manager.GetString("LblUserRegDateFromTitle", CultureInfo.CurrentCulture);
            LBL_USER_REG_DATE_TO_TITLE = manager.GetString("LblUserRegDateToTitle", CultureInfo.CurrentCulture);
            LBL_BALANCE_TITLE = manager.GetString("LblBalanceTitle", CultureInfo.CurrentCulture);
            LBL_ADDRESS_TITLE = manager.GetString("LblAddressTitle", CultureInfo.CurrentCulture);
            LBL_EMAIL_TITLE = manager.GetString("LblEmailTitle", CultureInfo.CurrentCulture);
            LBL_PHONE_TITLE = manager.GetString("LblPhoneTitle", CultureInfo.CurrentCulture);
            LBL_USER_B_DATE_FROM_TITLE = manager.GetString("LblUserBDateFromTitle", CultureInfo.CurrentCulture);
            LBL_USER_B_DATE_TO_TITLE = manager.GetString("LblUserBDateToTitle", CultureInfo.CurrentCulture);
            LBL_DISPLAY_NAME_TITLE = manager.GetString("LblDisplayNameTitle", CultureInfo.CurrentCulture);
            LBL_PASSWORD_TITLE = manager.GetString("LblPasswordTitle", CultureInfo.CurrentCulture);
            LBL_USERNAME_TITLE = manager.GetString("LblUsernameTitle", CultureInfo.CurrentCulture);
            LBL_ID_TITLE = manager.GetString("LblIDTitle", CultureInfo.CurrentCulture);
            LBL_VENDOR_NAME_TITLE = manager.GetString("LblVendorNameTitle", CultureInfo.CurrentCulture);
            LBL_QUANTITY_TITLE = manager.GetString("LblQuantityTitle", CultureInfo.CurrentCulture);
            LBL_PRICE_TITLE = manager.GetString("LblPriceTitle", CultureInfo.CurrentCulture);
            LBL_PRICE_OVERRIDE_TITLE = manager.GetString("LblPriceOverrideTitle", CultureInfo.CurrentCulture);
            LBL_S_LOCATION_TITLE = manager.GetString("LblSLocationTitle", CultureInfo.CurrentCulture);
            LBL_PRODUCT_EXP_DATE_FROM_TITLE = manager.GetString("LblProductExpDateFromTitle", CultureInfo.CurrentCulture);
            LBL_PRODUCT_EXP_DATE_TO_TITLE = manager.GetString("LblProductExpDateToTitle", CultureInfo.CurrentCulture);
            LBL_PRODUCT_NOTICE_TITLE = manager.GetString("LblProductNoticeTitle", CultureInfo.CurrentCulture);
            LBL_PRODUCT_IMAGE_NOTICE_TITLE = manager.GetString("LblProductImageNoticeTitle", CultureInfo.CurrentCulture);
            PRODUCT_DESCRIPTION_SEARCH_TOOLTIP_TITLE = manager.GetString("ProductDescriptionSearchTooltipTitle", CultureInfo.CurrentCulture);
            DGV_PRODUCTS_TOOLTIP_TITLE = manager.GetString("DgvProductsTooltipTitle", CultureInfo.CurrentCulture);
            DGV_PRODUCT_ORDERS_TOOLTIP_TITLE = manager.GetString("DgvProductOrdersTooltipTitle", CultureInfo.CurrentCulture);
            SELECTED_PRODUCT_IMAGE_TOOLTIP_TITLE = manager.GetString("SelectedProductImageTooltipTitle", CultureInfo.CurrentCulture);
            REFERENCED_ID_SEARCH_TOOLTIP_TITLE = manager.GetString("ReferencedIDSearchTooltipTitle", CultureInfo.CurrentCulture);
            LBL_VENDOR_TITLE = manager.GetString("LblVendorTitle", CultureInfo.CurrentCulture);
            LBL_BRAND_TITLE = manager.GetString("LblBrandTitle", CultureInfo.CurrentCulture);
            LBL_PART_NUM_TITLE = manager.GetString("LblPartNumTitle", CultureInfo.CurrentCulture);
            LBL_REG_NUM_TITLE = manager.GetString("LblRegNumTitle", CultureInfo.CurrentCulture);
            LBL_PRODUCT_DESCRIPTION_TITLE = manager.GetString("LblProductDescriptionTitle", CultureInfo.CurrentCulture);
            LBL_PRODUCT_NAME_TITLE = manager.GetString("LblProductNameTitle", CultureInfo.CurrentCulture);
            LBL_IMAGE_NAME_TITLE = manager.GetString("LblImageNameTitle", CultureInfo.CurrentCulture);
            LBL_IMAGE_ID_TITLE = manager.GetString("LblImageIDTitle", CultureInfo.CurrentCulture);
            LBL_REFERENCED_ID_TITLE = manager.GetString("LblReferencedIDTitle", CultureInfo.CurrentCulture);
            LBL_IMAGES_TITLE = manager.GetString("LblImagesTitle", CultureInfo.CurrentCulture);
            LBL_ORDER_REASON_TITLE = manager.GetString("LblOrderReasonTitle", CultureInfo.CurrentCulture);
            LBL_DATE_ADDED_TO_TITLE = manager.GetString("LblPODateAddedToTitle", CultureInfo.CurrentCulture);
            LBL_DATE_ADDED_FROM_TITLE = manager.GetString("LblPODateAddedFromTitle", CultureInfo.CurrentCulture);
            LBL_EMPLOYEE_TITLE = manager.GetString("LblEmployeeTitle", CultureInfo.CurrentCulture);
            LBL_PRODUCT_TITLE = manager.GetString("LblProductTitle", CultureInfo.CurrentCulture);
            LBL_PRODUCT_ORDER_NOTICE_TITLE = manager.GetString("ProductOrderNoticeTitle", CultureInfo.CurrentCulture);
            LBL_ORDER_STATUS_TITLE = manager.GetString("LblOrderStatusTitle", CultureInfo.CurrentCulture);
            LBL_ORDER_STATUS_PENDING = manager.GetString("LblOrderStatusPending", CultureInfo.CurrentCulture);
            LBL_STATUS_PREPAID = manager.GetString("LblStatusPrepaid", CultureInfo.CurrentCulture);
            LBL_STATUS_PAID_ON_DELIVERY = manager.GetString("LblStatusPaidOnDelivery", CultureInfo.CurrentCulture);
            LBL_STATUS_DIRECTLY_PAID = manager.GetString("LblStatusDirectlyPaid", CultureInfo.CurrentCulture);
            LBL_STATUS_GENERATING_INVOICE = manager.GetString("LblStatusGeneratingInvoice", CultureInfo.CurrentCulture);
            LBL_STATUS_GENERATING_REPORT = manager.GetString("LblStatusGeneratingReport", CultureInfo.CurrentCulture);
            LBL_ORDER_STATUS_PROCESSING = manager.GetString("LblOrderStatusProcessing", CultureInfo.CurrentCulture);
            LBL_ORDER_STATUS_CANCELLED = manager.GetString("LblOrderStatusCancelled", CultureInfo.CurrentCulture);
            LBL_ORDER_STATUS_RETURNED = manager.GetString("LblOrderStatusReturned", CultureInfo.CurrentCulture);
            LBL_ORDER_STATUS_COMPLETED = manager.GetString("LblOrderStatusCompleted", CultureInfo.CurrentCulture);
            LBL_DATE_MODIFIED_TO_TITLE = manager.GetString("LblPODateModifiedToTitle", CultureInfo.CurrentCulture);
            LBL_DATE_MODIFIED_FROM_TITLE = manager.GetString("LblPODateModifiedFromTitle", CultureInfo.CurrentCulture);
            LBL_CLIENT_TITLE = manager.GetString("LblClientTitle", CultureInfo.CurrentCulture);
            LBL_DESIRED_QUANTITY_TITLE = manager.GetString("LblDesiredQuantityTitle", CultureInfo.CurrentCulture);
            LBL_BRAND_NAME_TITLE = manager.GetString("LblBrandNameTitle", CultureInfo.CurrentCulture);
            LBL_ADDRESS_TITLE = manager.GetString("LblMethodNameTitle", CultureInfo.CurrentCulture);
            DGV_PRODUCT_BRANDS_TOOLTIP_TITLE = manager.GetString("DgvProductBrandsTooltipTitle", CultureInfo.CurrentCulture);
            BRAND_NAME_COL_TITLE = manager.GetString("BrandNameColTitle", CultureInfo.CurrentCulture);
            BRAND_ID_COL_TITLE = manager.GetString("BrandIDColTitle", CultureInfo.CurrentCulture);
            DGV_PAYMENT_METHODS_TOOLTIP_TITLE = manager.GetString("DgvPaymentMethodsTooltipTitle", CultureInfo.CurrentCulture);
            LBL_METHOD_NAME_TITLE = manager.GetString("LblMethodNameTitle", CultureInfo.CurrentCulture);
            METHOD_ID_COL_TITLE = manager.GetString("MethodIDColTitle", CultureInfo.CurrentCulture);
            METHOD_NAME_COL_TITLE = manager.GetString("MethodNameColTitle", CultureInfo.CurrentCulture);
            PAYMENT_METHODS_TITLE = manager.GetString("PaymentMethodsTitle", CultureInfo.CurrentCulture);
            PAYMENT_METHODS_TOOLTIP_TITLE = manager.GetString("PaymentMethodsTooltipTitle", CultureInfo.CurrentCulture);
            DGV_ORDER_DELIVERIES_TOOLTIP_TITLE = manager.GetString("DgvOrderDeliveriesTooltipTitle", CultureInfo.CurrentCulture);
            TOTAL_PRICE_SEARCH_TOOLTIP_TITLE = manager.GetString("TotalPriceSearchTooltipTitle", CultureInfo.CurrentCulture);
            CARGO_ID_SEARCH_TOOLTIP_TITLE = manager.GetString("CargoIDSearchTooltipTitle", CultureInfo.CurrentCulture);
            LBL_CARGO_ID_TITLE = manager.GetString("LblCargoIDTitle", CultureInfo.CurrentCulture);
            LBL_DELIVERY_STATUS_TITLE = manager.GetString("LblDeliveryStatusTitle", CultureInfo.CurrentCulture);
            LBL_DELIVERY_STATUS_PENDING = manager.GetString("LblDeliveryStatusPending", CultureInfo.CurrentCulture);
            LBL_DELIVERY_STATUS_ON_THE_MOVE = manager.GetString("LblDeliveryStatusOnTheMove", CultureInfo.CurrentCulture);
            LBL_DELIVERY_STATUS_CANCELLED = manager.GetString("LblDeliveryStatusCancelled", CultureInfo.CurrentCulture);
            LBL_DELIVERY_STATUS_RETURNED = manager.GetString("LblDeliveryStatusReturned", CultureInfo.CurrentCulture);
            LBL_DELIVERY_STATUS_COMPLETED = manager.GetString("LblDeliveryStatusCompleted", CultureInfo.CurrentCulture);
            DELIVERY_STATUS_SEARCH_TOOLTIP_TITLE = manager.GetString("DeliveryStatusSearchTooltipTitle", CultureInfo.CurrentCulture);
            ORDER_DELIVERY_NOTICE_TITLE = manager.GetString("OrderDeliveryNoticeTitle", CultureInfo.CurrentCulture);
            OD_DATE_MODIFIED_TO_SEARCH_TOOLTIP_TITLE = manager.GetString("ODDateModifiedToSearchTooltipTitle", CultureInfo.CurrentCulture);
            OD_DATE_MODIFIED_FROM_SEARCH_TOOLTIP_TITLE = manager.GetString("ODDateModifiedFromSearchTooltipTitle", CultureInfo.CurrentCulture);
            PAYMENT_METHOD_SEARCH_TOOLTIP_TITLE = manager.GetString("PaymentMethodSearchTooltipTitle", CultureInfo.CurrentCulture);
            LBL_PAYMENT_METHOD_TITLE = manager.GetString("LblPaymentMethodTitle", CultureInfo.CurrentCulture);
            PRODUCT_ORDER_SEARCH_TOOLTIP_TITLE = manager.GetString("ProductOrderSearchTooltipTitle", CultureInfo.CurrentCulture);
            DELIVERY_SERVICE_SEARCH_TOOLTIP_TITLE = manager.GetString("DeliveryServiceSearchTooltipTitle", CultureInfo.CurrentCulture);
            LBL_TOTAL_PRICE_TITLE = manager.GetString("LblTotalPriceTitle", CultureInfo.CurrentCulture);
            DELIVERY_REASON_SEARCH_TOOLTIP_TITLE = manager.GetString("DeliveryReasonSearchTooltipTitle", CultureInfo.CurrentCulture);
            LBL_DELIVERY_REASON_TITLE = manager.GetString("LblDeliveryReasonTitle", CultureInfo.CurrentCulture);
            OD_DATE_ADDED_TO_SEARCH_TOOLTIP_TITLE = manager.GetString("ODDateAddedToSearchTooltipTitle", CultureInfo.CurrentCulture);
            OD_DATE_ADDED_FROM_SEARCH_TOOLTIP_TITLE = manager.GetString("ODDateAddedFromSearchTooltipTitle", CultureInfo.CurrentCulture);
            LBL_DELIVERY_SERVICE_TITLE = manager.GetString("LblDeliveryServiceTitle", CultureInfo.CurrentCulture);
            LBL_PRODUCT_ORDER_TITLE = manager.GetString("LblProductOrderTitle", CultureInfo.CurrentCulture);
            DELIVERY_ID_COL_TITLE = manager.GetString("DeliveryIDColTitle", CultureInfo.CurrentCulture);
            PRODUCT_ORDER_COL_TITLE = manager.GetString("ProductOrderColTitle", CultureInfo.CurrentCulture);
            TOTAL_PRICE_COL_TITLE = manager.GetString("TotalPriceColTitle", CultureInfo.CurrentCulture);
            DELIVERY_SERVICE_COL_TITLE = manager.GetString("DeliveryServiceColTitle", CultureInfo.CurrentCulture);
            PAYMENT_METHOD_COL_TITLE = manager.GetString("PaymentMethodColTitle", CultureInfo.CurrentCulture);
            CARGO_ID_COL_TITLE = manager.GetString("CargoIDColTitle", CultureInfo.CurrentCulture);
            DELIVERY_STATUS_COL_TITLE = manager.GetString("DeliveryStatusColTitle", CultureInfo.CurrentCulture);
            DELIVERY_REASON_COL_TITLE = manager.GetString("DeliveryReasonColTitle", CultureInfo.CurrentCulture);
            ORDER_DELIVERIES_TITLE = manager.GetString("OrderDeliveriesTitle", CultureInfo.CurrentCulture);
            ORDER_DELIVERIES_TOOLTIP_TITLE = manager.GetString("OrderDeliveriesTooltipTitle", CultureInfo.CurrentCulture);
            DELIVERY_PRICE_SEARCH_TOOLTIP_TITLE = manager.GetString("DeliveryPriceSearchTooltipTitle", CultureInfo.CurrentCulture);
            SERVICE_NAME_SEARCH_TOOLTIP_TITLE = manager.GetString("ServiceNameSearchTooltipTitle", CultureInfo.CurrentCulture);
            LBL_SERVICE_NAME_TITLE = manager.GetString("LblServiceNameTitle", CultureInfo.CurrentCulture);
            DGV_DELIVERY_SERVICES_TOOLTIP_TITLE = manager.GetString("DgvDeliveryServicesTooltipTitle", CultureInfo.CurrentCulture);
            SERVICE_ID_COL_TITLE = manager.GetString("ServiceIDColTitle", CultureInfo.CurrentCulture);
            SERVICE_NAME_COL_TITLE = manager.GetString("ServiceNameColTitle", CultureInfo.CurrentCulture);
            SERVICE_PRICE_COL_TITLE = manager.GetString("ServicePriceColTitle", CultureInfo.CurrentCulture);
            DELIVERY_SERVICES_TITLE = manager.GetString("DelieryServicesTitle", CultureInfo.CurrentCulture);
            DELIVERY_SERVICES_TOOLTIP_TITLE = manager.GetString("DelieryServicesTooltipTitle", CultureInfo.CurrentCulture);
            BTN_SEARCH_TITLE = manager.GetString("BtnSearchTitle", CultureInfo.CurrentCulture);
            BTN_SEARCH_PRODUCT_IMAGE_TITLE = manager.GetString("BtnSearchProductImageTitle", CultureInfo.CurrentCulture);
            BTN_DELETE_PRODUCT_IMAGE_TITLE = manager.GetString("BtnDeleteProductImageTitle", CultureInfo.CurrentCulture);
            BTN_ADD_EDIT_PRODUCT_IMAGE_TITLE = manager.GetString("BtnAddEditProductImageTitle", CultureInfo.CurrentCulture);
            PRODUCT_MENU_ACCESS_ADMIN_NOTICE = manager.GetString("ProductMenuAccessAdminNotice", CultureInfo.CurrentCulture);
            PRODUCT_MENU_ACCESS_EMPLOYEE_NOTICE = manager.GetString("ProductMenuAccessEmployeeNotice", CultureInfo.CurrentCulture);
            USER_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("UserMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            BRAND_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("BrandMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            VENDOR_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("VendorMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            PAYMENT_METHOD_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("PaymentMethodMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            DELIVERY_SERVICE_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("DeliveryServiceMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            PRODUCT_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("ProductMenuAccessErrorMessage", CultureInfo.CurrentCulture);
            PRODUCT_ORDER_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("ProductOrderMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            ORDER_DELIVERY_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("OrderDeliveryMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            LOGS_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("LogsMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            BULK_USER_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("BulkUserMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            BULK_BRAND_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("BulkBrandMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            BULK_VENDOR_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("BulkVendorMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            BULK_PAYMENT_METHOD_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("BulkPaymentMethodMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            BULK_DELIVERY_SERVICE_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("BulkDeliveryServiceMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            BULK_PRODUCT_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("BulkProductMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            BULK_PRODUCT_IMAGE_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("BulkProductImageMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            BULK_PRODUCT_ORDER_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("BulkProductOrderMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            BULK_ORDER_DELIVERY_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("BulkOrderDeliveryMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            ACCOUNT_SETTINGS_ERROR_MESSAGE = manager.GetString("AccountSettingsErrorMessage", CultureInfo.CurrentCulture);
            ACCOUNT_SETTINGS_INVALID_CREDENTIALS_ERROR_MESSAGE = manager.GetString("AccountSettingsInvalidCredentialsErrorMessage", CultureInfo.CurrentCulture);
            APPLICATION_SETTINGS_CHANGES_NOTICE = manager.GetString("ApplicationSettingsChangeNotice",CultureInfo.CurrentCulture);
            LANGUAGE_MANAGER_LANGUAGE_EXIST_ERROR_MESSAGE = manager.GetString("LanguageManagerLanguageExistErrorMessage", CultureInfo.CurrentCulture);
            LANGUAGE_MANAGER_LANGUAGE_NONEXISTENT_ERROR_MESSAGE = manager.GetString("LanguageManagerLanguageNonexistentErrorMessage", CultureInfo.CurrentCulture);
            REPORT_GENERATION_PERMISSION_ERROR = manager.GetString("ReportGenerationPermissionError", CultureInfo.CurrentCulture);
            USER_EDIT_OPERATION_PERMISSION_ERROR = manager.GetString("UserEditOperationPermissionError", CultureInfo.CurrentCulture);
            USER_DELETE_OPERATION_PERMISSION_ERROR = manager.GetString("UserDeleteOperationPermissionError", CultureInfo.CurrentCulture);
            RECORD_DELETION_WARNING = manager.GetString("RecordDeletionWarning", CultureInfo.CurrentCulture);
            VENDOR_EDIT_OPERATION_PERMISSION_ERROR = manager.GetString("VendorEditOperationPermissionError", CultureInfo.CurrentCulture);
            VENDOR_DELETE_OPERATION_PERMISSION_ERROR = manager.GetString("VendorDeleteOperationPermissionError", CultureInfo.CurrentCulture);
            PRODUCT_EDIT_OPERATION_PERMISSION_ERROR = manager.GetString("ProductEditOperationPermissionError", CultureInfo.CurrentCulture);
            PRODUCT_DELETE_OPERATION_PERMISSION_ERROR = manager.GetString("ProductDeleteOperationPermissionError",CultureInfo.CurrentCulture);
            PRODUCT_IMAGE_EDIT_OPERATION_PERMISSION_ERROR = manager.GetString("ProductImageEditOperationPermissionError", CultureInfo.CurrentCulture);
            PRODUCT_IMAGE_DELETE_OPERATION_PERMISSION_ERROR = manager.GetString("ProductImageDeleteOperationPermissionError", CultureInfo.CurrentCulture);
            PRODUCT_ORDER_TOTAL_PRICE_OVERRIDE_QUESTION = manager.GetString("ProductOrderTotalPriceOverrideQuestion", CultureInfo.CurrentCulture);
            BULK_PRODUCT_ORDER_TOTAL_PRICE_OVERRIDE_QUESTION = manager.GetString("BulkProductOrderTotalPriceOverrideQuestion", CultureInfo.CurrentCulture);
            PRODUCT_ORDER_DELETE_OPERATION_PERMISSION_ERROR = manager.GetString("ProductOrderDeleteOperationPermissionError", CultureInfo.CurrentCulture);
            PRODUCT_ORDER_EDIT_OPERATION_PERMISSION_ERROR = manager.GetString("ProductOrderEditOperationPermissionError", CultureInfo.CurrentCulture);
            PRODUCT_ORDER_INVOICE_GENERATION_QUESTION = manager.GetString("ProductOrderInvoiceGenerationQuestion", CultureInfo.CurrentCulture);
            ORDER_DELIVERY_DELETE_OPERATION_PERMISSION_ERROR = manager.GetString("OrderDeliveryDeleteOperationPermissionError", CultureInfo.CurrentCulture);
            ORDER_DELIVERY_EDIT_OPERATION_PERMISSION_ERROR = manager.GetString("OrderDeliveryEditOperationPermissionError", CultureInfo.CurrentCulture);
            ORDER_DELIVERY_INVOICE_GENERATION_QUESTION = manager.GetString("OrderDeliveryInvoiceGenerationQuestion", CultureInfo.CurrentCulture);
            BRAND_EDIT_OPERATION_PERMISSION_ERROR = manager.GetString("BrandEditOperationPermissionError", CultureInfo.CurrentCulture);
            BRAND_DELETE_OPERATION_PERMISSION_ERROR = manager.GetString("BrandDeleteOperationPermissionError", CultureInfo.CurrentCulture);
            PAYMENT_METHOD_EDIT_OPERATION_PERMISSION_ERROR = manager.GetString("PaymentMethodEditOperationPermissionError", CultureInfo.CurrentCulture);
            PAYMENT_METHOD_DELETE_OPERATION_PERMISSION_ERROR = manager.GetString("PaymentMethodDeleteOperationPermissionError", CultureInfo.CurrentCulture);
            DELIVERY_SERVICE_EDIT_OPERATION_PERMISSION_ERROR = manager.GetString("DeliveryServiceEditOperationPermissionError", CultureInfo.CurrentCulture);
            DELIVERY_SERVICE_DELETE_OPERATION_PERMISSION_ERROR = manager.GetString("DeliveryServiceDeleteOperationPermissionError", CultureInfo.CurrentCulture);
            BULK_OPERATION_OPERATION_ON_NAME = manager.GetString("BulkOperationOperationOnName",CultureInfo.CurrentCulture);
            BULK_OPERATION_OPERATION_ON_TARGET_ID_NAME = manager.GetString("BulkOperationOperatonOnTargetIDName", CultureInfo.CurrentCulture);
            BULK_OPERATION_UNAUTHORISED_ERROR_MESSAGE = manager.GetString("BulkOperationUnauthorisedErrorMessage", CultureInfo.CurrentCulture);
            BULK_USER_OPERATION_UNAUTHORISED_ERROR_MESSAGE = manager.GetString("BulkUserOperationUnauthorisedErrorMessage", CultureInfo.CurrentCulture);
            BULK_BRAND_OPERATION_UNAUTHORISED_ERROR_MESSAGE = manager.GetString("BulkBrandOperationUnauthorisedErrorMessage", CultureInfo.CurrentCulture);
            BULK_VENDOR_OPERATION_UNAUTHORISED_ERROR_MESSAGE = manager.GetString("BulkVendorOperationUnauthorisedErrorMessage", CultureInfo.CurrentCulture);
            BULK_PAYMENT_METHOD_OPERATION_UNAUTHORISED_ERROR_MESSAGE = manager.GetString("BulkPaymentMethodOperationUnauthorisedErrorMessage", CultureInfo.CurrentCulture);
            BULK_DELIVERY_SERVICE_OPERATION_UNAUTHORISED_ERROR_MESSAGE = manager.GetString("BulkDeliveryServiceOperationUnauthorisedErrorMessage", CultureInfo.CurrentCulture);
            BULK_PRODUCT_OPERATION_UNAUTHORISED_ERROR_MESSAGE = manager.GetString("BulkProductOperationUnauthorisedErrorMessage", CultureInfo.CurrentCulture);
            BULK_PRODUCT_IMAGE_OPERATION_UNAUTHORISED_ERROR_MESSAGE = manager.GetString("BulkProductImageOperationUnauthorisedErrorMessage", CultureInfo.CurrentCulture);
            BULK_PRODUCT_ORDER_OPERATION_UNAUTHORISED_ERROR_MESSAGE = manager.GetString("BulkProductOrderOperationUnauthorisedErrorMessage", CultureInfo.CurrentCulture);
            BULK_ORDER_DELIVERY_OPERATION_UNAUTHORISED_ERROR_MESSAGE = manager.GetString("BulkOrderDeliveryOperationUnauthorisedErrorMessage", CultureInfo.CurrentCulture);
            SAMPLE_BULK_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = manager.GetString("SampleBulkOperationCreateTaskSuccessMessage",CultureInfo.CurrentCulture);
            SAMPLE_BULK_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = manager.GetString("SampleBulkOperationUpdateTaskSuccessMessage", CultureInfo.CurrentCulture);
            SAMPLE_BULK_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = manager.GetString("SampleBulkOperationDeleteTaskSuccessMessage", CultureInfo.CurrentCulture);
            SAMPLE_BULK_OPERATION_CUSTOM_TASK_SUCCESS_MESSAGE = manager.GetString("SampleBulkOperationCustomTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_USER_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkUserOperationCreateTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_USER_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkUserOperationUpdateTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_USER_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkUserOperationDeleteTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_BRAND_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkBrandOperationCreateTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_BRAND_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkBrandOperationUpdateTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_BRAND_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkBrandOperationDeleteTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_VENDOR_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkVendorOperationCreateTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_VENDOR_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkVendorOperationUpdateTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_VENDOR_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkVendorOperationDeleteTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_PAYMENT_METHOD_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkPaymentMethodOperationCreateTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_PAYMENT_METHOD_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkPaymentMethodOperationUpdateTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_PAYMENT_METHOD_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkPaymentMethodOperationDeleteTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_DELIVERY_SERVICE_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkDeliveryServiceOperationCreateTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_DELIVERY_SERVICE_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkDeliveryServiceOperationUpdateTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_DELIVERY_SERVICE_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkDeliveryServiceOperationDeleteTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_PRODUCT_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkProductOperationCreateTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_PRODUCT_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkProductOperationUpdateTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_PRODUCT_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkProductOperationDeleteTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_PRODUCT_IMAGE_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkProductImageOperationCreateTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_PRODUCT_IMAGE_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkProductImageOperationUpdateTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_PRODUCT_IMAGE_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkProductImageOperationDeleteTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_PRODUCT_ORDER_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkProductOrderOperationCreateTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_PRODUCT_ORDER_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkProductOrderOperationUpdateTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_PRODUCT_ORDER_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkProductOrderOperationDeleteTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_ORDER_DELIVERY_OPERATION_CREATE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkOrderDeliveryOperationCreateTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_ORDER_DELIVERY_OPERATION_UPDATE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkOrderDeliveryOperationUpdateTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_ORDER_DELIVERY_OPERATION_DELETE_TASK_SUCCESS_MESSAGE = manager.GetString("BulkOrderDeliveryOperationDeleteTaskSuccessMessage", CultureInfo.CurrentCulture);
            BULK_OPERATION_START_TIME_MESSAGE = manager.GetString("BulkOperationStartTimeMessage", CultureInfo.CurrentCulture);
            BULK_OPERATION_EXECUTING_MESSAGE = manager.GetString("BulkOperationExecutingMessage", CultureInfo.CurrentCulture);
            BULK_OPERATION_SUCCESSFUL_MESSAGE = manager.GetString("BulkOperationSuccessfulMessage", CultureInfo.CurrentCulture);
            BULK_OPERATION_FAILED_MESSAGE = manager.GetString("BulkOperationFailedMessage", CultureInfo.CurrentCulture);
            BULK_OPERATION_ERROR_CODE_MESSAGE = manager.GetString("BulkOperationErrorCodeMessage", CultureInfo.CurrentCulture);
            BULK_OPERATION_ERROR_MESSAGE = manager.GetString("BulkOperationErrorMessage", CultureInfo.CurrentCulture);
            BULK_OPERATION_END_TIME_MESSAGE = manager.GetString("BulkOperationEndTimeMessage", CultureInfo.CurrentCulture);
            BULK_OPERATION_RESULTS_MESSAGE = manager.GetString("BulkOperationResultsMessage", CultureInfo.CurrentCulture);
            BULK_OPERATION_COMPLETED_COUNT_MESSAGE = manager.GetString("BulkOperationCompletedCountMessage", CultureInfo.CurrentCulture);
            BULK_OPERATION_FAILED_COUNT_MESSAGE = manager.GetString("BulkOperationFailedCountMessage", CultureInfo.CurrentCulture);
            BULK_OPERATION_EXECUTION_TIME_MESSAGE = manager.GetString("BulkOperationExecutionTimeMessage", CultureInfo.CurrentCulture);
            BULK_USER_OPERATION_NO_PERMISSION_MESSAGE = manager.GetString("BulkUserOperationNoPermissionMessage", CultureInfo.CurrentCulture);
            BULK_BRAND_OPERATION_NO_PERMISSION_MESSAGE = manager.GetString("BulkBrandOperationNoPermissionMessage", CultureInfo.CurrentCulture);
            BULK_VENDOR_OPERATION_NO_PERMISSION_MESSAGE = manager.GetString("BulkVendorOperationNoPermissionMessage", CultureInfo.CurrentCulture);
            BULK_PAYMENT_METHOD_OPERATION_NO_PERMISSION_MESSAGE = manager.GetString("BulkPaymentMethodOperationNoPermissionMessage", CultureInfo.CurrentCulture);
            BULK_DELIVERY_SERVICE_OPERATION_NO_PERMISSION_MESSAGE = manager.GetString("BulkDeliveryServiceOperationNoPermissionMessage", CultureInfo.CurrentCulture);
            BULK_PRODUCT_OPERATION_NO_PERMISSION_MESSAGE = manager.GetString("BulkProductOperationNoPermissionMessage", CultureInfo.CurrentCulture);
            BULK_PRODUCT_IMAGE_OPERATION_NO_PERMISSION_MESSAGE = manager.GetString("BulkProductImageOperationNoPermissionMessage", CultureInfo.CurrentCulture);
            BULK_PRODUCT_ORDER_OPERATION_NO_PERMISSION_MESSAGE = manager.GetString("BulkProductOrderOperationNoPermissionMessage", CultureInfo.CurrentCulture);
            BULK_ORDER_DELIVERY_OPERATION_NO_PERMISSION_MESSAGE = manager.GetString("BulkOrderDeliveryOperationNoPermissionMessage", CultureInfo.CurrentCulture);
            LBL_BULK_OPERATION_RESULTS_TEXT = manager.GetString("lblBulkOperationResultsText", CultureInfo.CurrentCulture);
            instance.InvokeCultureInfoChangedEvent(CultureInfo.CurrentCulture);
        }
    }
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static GLOBAL_RESOURCES resources;
        [STAThread]
        static void Main()
        {
            try
            {
                resources = new GLOBAL_RESOURCES();
                GLOBAL_RESOURCES.RefreshSettings();
                GLOBAL_RESOURCES.UpdateCurrentCultureResources();
                Process currentProccess = Process.GetCurrentProcess();
                bool IsAlreadyOpen = Process.GetProcessesByName(currentProccess.ProcessName).Any(p=>p.Id != currentProccess.Id);
                if(IsAlreadyOpen)
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.APPLICATION_INSTANCE_ERROR_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
