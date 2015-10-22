if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[umbracoContent]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[umbracoContent]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[umbracoContentAll]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[umbracoContentAll]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[umbracoContentData]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[umbracoContentData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cmsContentTypes]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[cmsContentTypes]
GO


EXEC dbo.sp_executesql @statement = N'create view cmsContentTypes as 
select * from umbracoNode  
inner join cmsContentType ct on ct.nodeId = umbracoNode.id 
left join cmsDocumentType dct on dct.contentTypeNodeId = ct.nodeId ' 
; 
EXEC dbo.sp_executesql @statement = N'CREATE view umbracoContentAll as                       
select                         
node.id nodeID,                         
cv.versionId as versionID,                         
0 as show,        
node.parentID,                         
node.nodeUser,                         
node.[level],                         
node.sortOrder,                         
cc.contentType,            
-1 as templateNodeId,                        
NULL as documentUser,                         
1 as language,                        
node.createdate as createdate,                  
NULL as releaseDate,                        
NULL as expireDate,                        
NULL as updateDate,                        
node.path,                        
node.text as nodeName,             
lower(replace(node.text,'' '','''')) as urlName,          
NULL as documentUserName,              
nodeUser.userName as nodeUserName,              
ct.alias,            
ctNode.text as nodeTypeName           
from                         
umbracoNode node              
inner join cmsContent cc on cc.nodeId = node.id        
inner join cmsContentVersion cv on cv.ContentId = cc.NodeId  
inner join cmsContentType ct on ct.nodeId = cc.contentType        
inner join umbracoNode ctNode on ctNode.id = ct.nodeId        
left join umbracoUser nodeUser on nodeUser.id = node.nodeUser';

EXEC dbo.sp_executesql @statement = N'CREATE  view umbracoContent as 
select  
node.id nodeID,  
cd.versionId as versionID,  
cd.published as show,  
node.parentID,  
node.nodeUser,  
node.[level],  
node.sortOrder,                       
cc.contentType,          
isnull(cd.templateId,dct.templateNodeId) as templateNodeId,  
 
cd.documentUser,                      
1 as language,                      
node.createdate as createdate,                
cd.updateDate,                      
cd.releasedate,                      
cd.expiredate,                      
node.path,                      
cd.text as nodeName,           
lower(cd.text) as urlName,        
versionUser.userName as versionUserName,            
nodeUser.userName as nodeUserName,            
ct.alias,          
ctNode.text as nodeTypeName         
from                       
umbracoNode node            
inner join cmsContent cc on cc.nodeId = node.id      
inner join cmsDocument cd on cd.nodeId = node.id and published = 1      
inner join cmsContentType ct on ct.nodeId = cc.contentType      
inner join umbracoNode ctNode on ctNode.id = ct.nodeId      
left join cmsDocumentType dct on dct.contentTypeNodeId = ct.NodeId and 
dct.isDefault = 1     
left join umbracoUser nodeUser on nodeUser.id = node.nodeUser            
left join umbracoUser versionUser on versionUser.id = cd.documentUser     
and node.nodeObjectType = ''C66BA18E-EAF3-4CFF-8A22-41B16D66A972'' 
and node.parentID <> -10'; 

EXEC dbo.sp_executesql @statement = N'CREATE view umbracoContentData as     
select  
	versionId as versionId,  
	cmsPropertyType.Alias as alias,  
	COALESCE(dataNtext, dataNvarchar, convert(nvarchar(1000), dataDate),convert(nvarchar(1000), dataInt)) as content  
from  
	cmsPropertyData 
inner join  
	cmsPropertyType on cmsPropertyType.id = cmsPropertyData.propertyTypeId   ';
 