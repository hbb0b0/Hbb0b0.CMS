<template>
<div class="common-margin">
  <el-form ref="form" :model="form" label-width="80px">
    <el-form-item label="名称">
      <el-input v-model="form.name" ></el-input>
    </el-form-item>
    <el-form-item>
   <div style="height: 10px; background-color: rgb(242, 242, 242);"></div>
  <div id="table">
    <el-table :data="form.titleList" stripe style="width: 100%" border>
      <el-table-column prop="title" sortable label="title">
      </el-table-column>
      <el-table-column prop="from_Date" sortable label="from">
      </el-table-column>
      <el-table-column prop="to_Date" sortable label="to">
      </el-table-column>
  
    </el-table>
  </div>
  </el-form-item>
    <el-form-item>
      <el-button type="primary" >保存</el-button>
      <el-button @click="gotoEmployeeList">返回</el-button>
    </el-form-item>
  </el-form>
</div>
</template>

<script>
export default {
  data() {
    return {
      form: {
        name: '',
        titleList:[],
        departmentList:[],
        salaryList:[]
      }
    }
  },
  methods: {
    gotoEmployeeList() {
      this.$router.push('/index/EmployeeList/')
    },
    getDetail() {
      let _self = this;
      debugger;
      let emp_no= this.$route.params.id;
      let url = "/Employee/GetDetail/"+emp_no;
      //debugger;
      _self.$http
        .get(url)
        .then(function(response) {
          debugger;
          //console.log(response.data.data);
          _self.form = response.data.data;

        })
        .catch(function(error) {
          console.log(error);
        });
    }
  },
  mounted: function(){
    this.getDetail();
  }

}
</script>
<style scoped>
@import '/static/default.css';
</style>