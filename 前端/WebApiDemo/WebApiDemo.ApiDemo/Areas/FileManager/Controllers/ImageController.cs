using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Api.WebModel.Common;
using WebApiDemo.ApiDemo.Areas.FileManager.Models;
using WebApiDemo.CommonLib.Tools.File;
using WebApiDemo.Model.EnumCommon;

namespace WebApiDemo.ApiDemo.Areas.FileManager.Controllers
{
    
    [ApiController]
    public class ImageController : FileBaseController
    {
        public ResultModel ImageUpload()
        {
            ResultModel resultModel = new ResultModel();
            IFormFileCollection files = Request.Form.Files;
            if (files == null || files.Count == 0)
            {
                resultModel.result_code = ResultCode.Fail;
                resultModel.result_mess = "未接收到文件!";
                return resultModel;
            }
            List<FileModel> fileList = new List<FileModel>();
            //定义图片数组后缀格式
            string[] LimitPictureType = { ".jpg", ".jpeg", ".gif", ".png", ".bmp" };
            try
            {
                foreach (var file in files)
                {
                    FileModel model = new FileModel();
                    fileList.Add(model);
                    model.FileOldName = file.FileName;
                    //获取图片后缀是否存在数组中
                    string currentPictureExtension = Path.GetExtension(file.FileName).ToLower();
                    if (!LimitPictureType.Contains(currentPictureExtension))
                    {
                        model.Mess = "不是图片文件,请上传图片文件";
                        continue;
                    }
                    Guid guid = Guid.NewGuid();
                    string serverFilePath = "/UpLoadFile/Image";
                    string fileNewName = guid.ToString() + currentPictureExtension;
                    string filePath = FileUtil.MapPath("/wwwroot"+serverFilePath);
                    using (var stream = new FileStream(filePath + "/" + fileNewName, FileMode.Create))
                    {
                        //再把文件保存的文件夹中
                        file.CopyTo(stream);
                    }
                    model.FileOldName = file.FileName;
                    model.FileNewName = fileNewName;
                    model.FilePath = serverFilePath + "/" + model.FileNewName;
                }
                resultModel.result_code = ResultCode.Ok;
                resultModel.result_data = fileList;
                resultModel.result_mess = "上传成功";
               
            }
            catch (Exception ex)
            {
                resultModel.result_code = ResultCode.Error;
                resultModel.result_mess = "出现错误";
            }
            return resultModel;

        }
    }
}