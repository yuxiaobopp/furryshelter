<template>
  <a-modal
    :title="title"
    width="40%"
    :visible="visible"
    :confirmLoading="loading"
    @ok="handleSubmit"
    @cancel="()=>{this.visible=false}"
  >
    <a-spin :spinning="loading">
      <a-form-model ref="form" :model="entity" :rules="rules" v-bind="layout">
        <a-form-model-item label="用户名" prop="UserName">
          <a-input v-model="entity.UserName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="密码" prop="Password">
          <a-input v-model="entity.Password" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="姓名" prop="RealName">
          <a-input v-model="entity.RealName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="性别(1为男，0为女)" prop="Sex">
          <a-input v-model="entity.Sex" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="电话号码" prop="Phone">
          <a-input v-model="entity.Phone" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="身份证实名" prop="IdentityCardNo">
          <a-input v-model="entity.IdentityCardNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="否已实名" prop="IfVerifyCardNo">
          <a-input v-model="entity.IfVerifyCardNo" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="出生日期" prop="Birthday">
          <a-input v-model="entity.Birthday" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="省" prop="Province">
          <a-input v-model="entity.Province" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="市" prop="City">
          <a-input v-model="entity.City" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="否已养宠物" prop="IfPet">
          <a-input v-model="entity.IfPet" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="邮箱" prop="Email">
          <a-input v-model="entity.Email" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="邮箱验证码" prop="EmailCode">
          <a-input v-model="entity.EmailCode" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="否已验证邮箱" prop="IfVeryfyEmail">
          <a-input v-model="entity.IfVeryfyEmail" autocomplete="off" />
        </a-form-model-item>
      </a-form-model>
    </a-spin>
  </a-modal>
</template>

<script>
export default {
  props: {
    parentObj: Object
  },
  data() {
    return {
      layout: {
        labelCol: { span: 5 },
        wrapperCol: { span: 18 }
      },
      visible: false,
      loading: false,
      entity: {},
      rules: {},
      title: ''
    }
  },
  methods: {
    init() {
      this.visible = true
      this.entity = {}
      this.$nextTick(() => {
        this.$refs['form'].clearValidate()
      })
    },
    openForm(id, title) {
      this.init()

      if (id) {
        this.loading = true
        this.$http.post('/Front_Domain/front_user/GetTheData', { id: id }).then(resJson => {
          this.loading = false

          this.entity = resJson.Data
        })
      }
    },
    handleSubmit() {
      this.$refs['form'].validate(valid => {
        if (!valid) {
          return
        }
        this.loading = true
        this.$http.post('/Front_Domain/front_user/SaveData', this.entity).then(resJson => {
          this.loading = false

          if (resJson.Success) {
            this.$message.success('操作成功!')
            this.visible = false

            this.parentObj.getDataList()
          } else {
            this.$message.error(resJson.Msg)
          }
        })
      })
    }
  }
}
</script>
