(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-2d2097b7"],{a8f0:function(e,t,i){"use strict";i.r(t);var a=function(){var e=this,t=this,i=t.$createElement,a=t._self._c||i;return a("a-modal",{attrs:{title:"编辑表单",width:"40%",visible:t.visible,confirmLoading:t.confirmLoading},on:{ok:t.handleSubmit,cancel:function(){e.visible=!1}}},[a("a-spin",{attrs:{spinning:t.confirmLoading}},[a("a-form-model",t._b({ref:"form",attrs:{model:t.entity,rules:t.rules}},"a-form-model",t.layout,!1),[a("a-form-model-item",{attrs:{label:"生成类型",prop:"buildTypes"}},[a("a-checkbox-group",{model:{value:t.entity.buildTypes,callback:function(e){t.$set(t.entity,"buildTypes",e)},expression:"entity.buildTypes"}},[a("a-checkbox",{attrs:{value:"0",name:"buildTypes"}},[t._v("实体层")]),a("a-checkbox",{attrs:{value:"1",name:"buildTypes"}},[t._v("业务层")]),a("a-checkbox",{attrs:{value:"2",name:"buildTypes"}},[t._v("接口层")]),a("a-checkbox",{attrs:{value:"3",name:"buildTypes"}},[t._v("页面层")])],1)],1),a("a-form-model-item",{attrs:{label:"生成区域",prop:"areaName"}},[a("a-input",{attrs:{autocomplete:"off"},model:{value:t.entity.areaName,callback:function(e){t.$set(t.entity,"areaName",e)},expression:"entity.areaName"}})],1)],1)],1)],1)},n=[],s={data:function(){return{layout:{labelCol:{span:5},wrapperCol:{span:18}},visible:!1,confirmLoading:!1,entity:{buildTypes:[]},rules:{buildTypes:[{required:!0,message:"必填"}],areaName:[{required:!0,message:"必填"}]}}},methods:{init:function(){var e=this;this.visible=!0,this.entity={buildTypes:["0","1","2","3"]},this.$nextTick(function(){e.$refs["form"].clearValidate()})},openForm:function(e,t){this.init(),this.entity.tables=e,this.entity.linkId=t},handleSubmit:function(){var e=this;this.$refs["form"].validate(function(t){t&&(e.confirmLoading=!0,e.$http.post("/Base_Manage/BuildCode/Build",e.entity).then(function(t){e.confirmLoading=!1,t.Success?(e.$message.success("操作成功!"),e.visible=!1):e.$message.error(t.Msg)}))})}}},l=s,o=i("2877"),r=Object(o["a"])(l,a,n,!1,null,null,null);t["default"]=r.exports}}]);