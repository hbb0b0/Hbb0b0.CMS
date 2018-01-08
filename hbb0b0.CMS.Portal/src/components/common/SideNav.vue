<template>
    <el-menu default-active="/testManagement" class="el-menu-vertical-demo" router>
    <el-submenu index="1">
      <template slot="title"><i class="el-icon-message"></i>VUE 基础组件</template>
      <el-menu-item-group>
        <template slot="title">业务模块</template>
         
          <el-menu-item index="/index/departmentList">部门信息</el-menu-item>
           <el-menu-item index="/index/employeeList">员工信息</el-menu-item>
      </el-menu-item-group>
    </el-submenu>
    <el-menu-item index="/index/help"><i class="el-icon-menu"></i>帮助中心</el-menu-item>
    <el-menu-item index="/index/feedback"><i class="el-icon-setting"></i>意见反馈</el-menu-item>
  </el-menu>

</template>
