/*
 * Copyright 2010-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 * 
 *  http://aws.amazon.com/apache2.0
 * 
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

using Amazon.Glacier.Model;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;
using ThirdParty.Json.LitJson;

namespace Amazon.Glacier.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// Abort Multipart Upload Request Marshaller
    /// </summary>       
    internal class AbortMultipartUploadRequestMarshaller : IMarshaller<IRequest, AbortMultipartUploadRequest> 
    {
        

        public IRequest Marshall(AbortMultipartUploadRequest abortMultipartUploadRequest) 
        {

            IRequest request = new DefaultRequest(abortMultipartUploadRequest, "AmazonGlacier");
            string target = "Glacier.AbortMultipartUpload";
            request.Headers["X-Amz-Target"] = target;
            request.Headers["Content-Type"] = "application/x-amz-json-1.0";

            request.HttpMethod = "DELETE";
              
            string uriResourcePath = "/{accountId}/vaults/{vaultName}/multipart-uploads/{uploadId}"; 
            if(abortMultipartUploadRequest.IsSetAccountId())
                uriResourcePath = uriResourcePath.Replace("{accountId}", StringUtils.FromString(abortMultipartUploadRequest.AccountId) ); 
            else
                uriResourcePath = uriResourcePath.Replace("{accountId}", "" ); 
            if(abortMultipartUploadRequest.IsSetVaultName())
                uriResourcePath = uriResourcePath.Replace("{vaultName}", StringUtils.FromString(abortMultipartUploadRequest.VaultName) ); 
            else
                uriResourcePath = uriResourcePath.Replace("{vaultName}", "" ); 
            if(abortMultipartUploadRequest.IsSetUploadId())
                uriResourcePath = uriResourcePath.Replace("{uploadId}", StringUtils.FromString(abortMultipartUploadRequest.UploadId) ); 
            else
                uriResourcePath = uriResourcePath.Replace("{uploadId}", "" ); 
            
            if (uriResourcePath.Contains("?")) 
            {
                string queryString = uriResourcePath.Substring(uriResourcePath.IndexOf("?") + 1);
                uriResourcePath    = uriResourcePath.Substring(0, uriResourcePath.IndexOf("?"));
        
                foreach (string s in queryString.Split('&', ';')) 
                {
                    string[] nameValuePair = s.Split('=');
                    if (nameValuePair.Length == 2 && nameValuePair[1].Length > 0) 
                    {
                        request.Parameters.Add(nameValuePair[0], nameValuePair[1]);
                    }
                    else
                    {
                        request.Parameters.Add(nameValuePair[0], null);
                    }
                }
            }
            
            request.ResourcePath = uriResourcePath;
            
        
            request.UseQueryString = true;
        

            return request;
        }
    }
}
