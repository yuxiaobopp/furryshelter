(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-8a0a96b2","chunk-7a01d532"],{"1af6":function(t,e,a){var n=a("63b6");n(n.S,"Array",{isArray:a("9003")})},"4fac":function(t,e,a){"use strict";var n=a("58c2"),i=a.n(n);i.a},"581c":function(t,e,a){"use strict";a.r(e);var n=function(){var t=this,e=this,a=e.$createElement,n=e._self._c||a;return n("a-modal",{attrs:{title:"编辑表单",width:"40%",visible:e.visible,confirmLoading:e.confirmLoading},on:{ok:e.handleSubmit,cancel:function(){t.visible=!1}}},[n("a-spin",{attrs:{spinning:e.confirmLoading}},[n("a-form-model",e._b({ref:"form",attrs:{model:e.entity,rules:e.rules}},"a-form-model",e.layout,!1),[n("a-form-model-item",{attrs:{label:"菜单名",prop:"Name"}},[n("a-input",{attrs:{autocomplete:"off"},model:{value:e.entity.Name,callback:function(t){e.$set(e.entity,"Name",t)},expression:"entity.Name"}})],1),n("a-form-model-item",{attrs:{label:"上级菜单",prop:"ParentId"}},[n("a-tree-select",{attrs:{allowClear:"",treeData:e.ParentIdTreeData,placeholder:"请选择上级菜单",treeDefaultExpandAll:""},model:{value:e.entity.ParentId,callback:function(t){e.$set(e.entity,"ParentId",t)},expression:"entity.ParentId"}})],1),n("a-form-model-item",{attrs:{label:"类型",prop:"Type"}},[n("a-radio-group",{model:{value:e.entity.Type,callback:function(t){e.$set(e.entity,"Type",t)},expression:"entity.Type"}},[n("a-radio",{attrs:{value:0}},[e._v("菜单")]),n("a-radio",{attrs:{value:1}},[e._v("页面")])],1)],1),n("a-form-model-item",{attrs:{label:"路径",prop:"Url"}},[n("a-input",{attrs:{autocomplete:"off"},model:{value:e.entity.Url,callback:function(t){e.$set(e.entity,"Url",t)},expression:"entity.Url"}})],1),n("a-form-model-item",{attrs:{label:"是否需要权限",prop:"NeedAction"}},[n("a-radio-group",{model:{value:e.entity.NeedAction,callback:function(t){e.$set(e.entity,"NeedAction",t)},expression:"entity.NeedAction"}},[n("a-radio",{attrs:{value:!1}},[e._v("否")]),n("a-radio",{attrs:{value:!0}},[e._v("是")])],1)],1),n("a-form-model-item",{attrs:{label:"图标",prop:"Icon"}},[n("a-input",{attrs:{autocomplete:"off"},model:{value:e.entity.Icon,callback:function(t){e.$set(e.entity,"Icon",t)},expression:"entity.Icon"}})],1),n("a-form-model-item",{attrs:{label:"排序",prop:"Sort"}},[n("a-input",{attrs:{type:"number",autocomplete:"off"},model:{value:e.entity.Sort,callback:function(t){e.$set(e.entity,"Sort",t)},expression:"entity.Sort"}})],1),n("a-card",{attrs:{title:"页面权限",bordered:!1}},[n("Permission-List",{ref:"permissionList",attrs:{parentObj:this}})],1)],1)],1)],1)},i=[],r=a("e62b"),o={props:{afterSubmit:{type:Function,default:null}},components:{PermissionList:r["default"]},data:function(){return{layout:{labelCol:{span:5},wrapperCol:{span:18}},visible:!1,confirmLoading:!1,entity:{},ParentIdTreeData:[],rules:{Name:[{required:!0,message:"必填"}],Type:[{required:!0,message:"必填"}],NeedAction:[{required:!0,message:"必填"}]}}},methods:{init:function(t){var e=this;this.visible=!0,this.entity={},this.$nextTick(function(){e.$refs.permissionList.init(t),e.$refs["form"].clearValidate()}),this.$http.post("/Base_Manage/Base_Action/GetMenuTreeList",{}).then(function(t){t.Success&&(e.ParentIdTreeData=t.Data)})},openForm:function(t){var e=this;this.init(t),t&&this.$http.post("/Base_Manage/Base_Action/GetTheData",{id:t}).then(function(t){e.entity=t.Data})},handleSubmit:function(){var t=this;this.$refs["form"].validate(function(e){e&&(t.confirmLoading=!0,t.entity.permissionList=t.$refs.permissionList.getPermissionList(),t.$http.post("/Base_Manage/Base_Action/SaveData",t.entity).then(function(e){t.confirmLoading=!1,e.Success?(t.$message.success("操作成功!"),t.afterSubmit(),t.visible=!1):t.$message.error(e.Msg)}))})}}},s=o,c=a("2877"),l=Object(c["a"])(s,n,i,!1,null,null,null);e["default"]=l.exports},"58c2":function(t,e,a){},"75fc":function(t,e,a){"use strict";var n=a("a745"),i=a.n(n);function r(t){if(i()(t)){for(var e=0,a=new Array(t.length);e<t.length;e++)a[e]=t[e];return a}}var o=a("774e"),s=a.n(o),c=a("c8bb"),l=a.n(c);function u(t){if(l()(Object(t))||"[object Arguments]"===Object.prototype.toString.call(t))return s()(t)}function d(){throw new TypeError("Invalid attempt to spread non-iterable instance")}function f(t){return r(t)||u(t)||d()}a.d(e,"a",function(){return f})},"774e":function(t,e,a){t.exports=a("d2d5")},a745:function(t,e,a){t.exports=a("f410")},c8bb:function(t,e,a){t.exports=a("54a1")},e62b:function(t,e,a){"use strict";a.r(e);var n=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("a-spin",{attrs:{spinning:t.loading}},[a("div",{staticClass:"table-operator"},[a("a-button",{staticClass:"editable-add-btn",attrs:{icon:"plus",type:"default"},on:{click:t.handleAdd}},[t._v("添加权限")])],1),a("a-table",{attrs:{columns:t.columns,dataSource:t.data,bordered:"",size:"small",pagination:!1},scopedSlots:t._u([t._l(["Name","Value"],function(e){return{key:e,fn:function(n,i){return[a("div",{key:e},[i.editable?a("a-input",{staticStyle:{margin:"-5px 0"},attrs:{value:n},on:{change:function(a){return t.handleChange(a.target.value,i.key,e)}}}):[t._v(t._s(n))]],2)]}}}),{key:"operation",fn:function(e,n){return[a("div",{staticClass:"editable-row-operations"},[n.editable?a("span",[a("a",{on:{click:function(){return t.save(n.key)}}},[t._v("保存")]),a("br"),a("a-popconfirm",{attrs:{title:"确认取消吗?"},on:{confirm:function(){return t.cancel(n.key)}}},[a("a",[t._v("取消")])])],1):a("span",[a("a",{on:{click:function(){return t.edit(n.key)}}},[t._v("编辑")]),t.data.length?a("a-popconfirm",{attrs:{title:"确认删除吗?"},on:{confirm:function(){return t.onDelete(n.key)}}},[a("a",{attrs:{href:"javascript:;"}},[t._v("删除")])]):t._e()],1)])]}}],null,!0)})],1)},i=[],r=(a("ac6a"),a("cebc")),o=a("75fc"),s=a("7ecf"),c=[{title:"权限名",dataIndex:"Name",width:"30%",scopedSlots:{customRender:"Name"}},{title:"权限值(唯一)",dataIndex:"Value",width:"50%",scopedSlots:{customRender:"Value"}},{title:"操作",dataIndex:"operation",scopedSlots:{customRender:"operation"}}],l={data:function(){return{data:[],columns:c,loading:!1,parentId:null}},methods:{handleChange:function(t,e,a){var n=Object(o["a"])(this.data),i=n.filter(function(t){return e===t.key})[0];i&&(i[a]=t,this.data=n)},edit:function(t){var e=Object(o["a"])(this.data),a=e.filter(function(e){return t===e.key})[0];a&&(a.editable=!0,this.data=e)},save:function(t){var e=Object(o["a"])(this.data),a=e.filter(function(e){return t===e.key})[0];a&&(delete a.editable,this.data=e,this.resetCache(e))},cancel:function(t){var e=Object(o["a"])(this.data),a=e.filter(function(e){return t===e.key})[0];a&&(Object.assign(a,this.cacheData.filter(function(e){return t===e.key})[0]),delete a.editable,this.data=e)},onDelete:function(t){var e=Object(o["a"])(this.data);this.data=e.filter(function(e){return e.key!==t})},handleAdd:function(){var t={key:s.v4(),Name:"权限名",Value:"权限值",Type:2,ParentId:this.parentId};this.data=[].concat(Object(o["a"])(this.data),[t])},getPermissionList:function(){return this.data},handleSave:function(){var t=this;this.loading=!0,this.$http.post("/Base_Manage/Base_Action/SavePermission",{parentId:this.parentId,permissionListJson:JSON.stringify(this.data)}).then(function(e){t.loading=!1,e.Success?(t.$message.success("权限设置成功"),t.getDataList()):t.$message.error("操作失败")})},resetCache:function(t){this.cacheData=t.map(function(t){return Object(r["a"])({},t)})},getDataList:function(){var t=this;this.loading=!0,this.$http.post("/Base_Manage/Base_Action/GetPermissionList",{parentId:this.parentId}).then(function(e){t.loading=!1,e.Data.forEach(function(t){return t["key"]=s.v4()}),t.data=e.Data,t.resetCache(t.data)})},init:function(t){this.parentId=t,this.data=[],this.parentId&&this.getDataList()}}},u=l,d=(a("4fac"),a("2877")),f=Object(d["a"])(u,n,i,!1,null,"d27cb9a2",null);e["default"]=f.exports},f410:function(t,e,a){a("1af6"),t.exports=a("584a").Array.isArray}}]);