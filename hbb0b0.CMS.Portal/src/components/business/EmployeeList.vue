<template>
<div class="testUser">
  <div class="function">
    <el-row>
      <el-form label-width="80px" class="common-margin">
        <el-form-item label="名称">
          <el-col :span="6">
            <el-input placeholder="名称" v-model="queryCondition.param.name"></el-input>
          </el-col>
        </el-form-item>
        <el-form-item label="性别">
          <el-col :span="6">
            <el-select placeholder="性别" v-model="queryCondition.param.gender">
              <el-option v-for="item in genderStatus" :key="item.value" :label="item.label" :value="item.value">
              </el-option>
            </el-select>
          </el-col>
        </el-form-item>
        <el-form-item label="入职日期">
          <el-date-picker format="yyyy-MM-dd" v-model="queryCondition.param.hire_date_range" type="daterange" start-placeholder="开始日期" end-placeholder="结束日期"  default-value="1980-01-01">
          </el-date-picker>

        </el-form-item>
        <el-form-item label="出生日期">
          <el-date-picker format="yyyy-MM-dd" :editable="false" v-model="queryCondition.param.birth_date_range" type="daterange" start-placeholder="开始日期" end-placeholder="结束日期" default-value="1950-01-01"></el-date-picker>

        </el-form-item>
        <el-form-item label="">
          <el-button type="primary" @click="getData()">查询</el-button>
        </el-form-item>
      </el-form>
    </el-row>
  </div>
  <div style="height: 10px; background-color: rgb(242, 242, 242);"></div>
  <div id="table">
    <el-table :data="pageList.items" stripe style="width: 100%" border>
      <el-table-column prop="emp_No" sortable label="编号">
      </el-table-column>
      <el-table-column prop="name" sortable label="名称">
      </el-table-column>
      <el-table-column prop="gender" sortable label="性别">
      </el-table-column>
      <el-table-column prop="hire_Date_Display" sortable label="入职日期">
      </el-table-column>
      <el-table-column prop="birth_Date_Display" sortable label="出生日期">
      </el-table-column>

      <el-table-column  label="操作">
       <template slot-scope="scope">
        <el-button
          @click="getDetail(scope.row)"
          type="text"
          size="small">
          详细信息
        </el-button>
      </template>
      </el-table-column>
     
    </el-table>
    <div class="block">
      <el-pagination :data="pageList" @size-change="handleSizeChange" @current-change="handleCurrentChange" :current-page="queryCondition.pageInfo.pageIndex" :page-sizes="[10,100, 200, 300, 400]" :page-size="queryCondition.pageInfo.pageSize" layout="total, sizes, prev, pager, next, jumper"
        :total="pageList.totalCount">
      </el-pagination>
    </div>
  </div>
</div>
</template>

<script>
export default {
  data() {
    return {
      input: "",
      pageList: [],
      genderStatus: [{
          vale: "",
          label: ""
        },
        {
          value: "F",
          label: "Female"
        },
        {
          value: "M",
          label: "Male"
        }
      ],
      queryCondition: {

        param: {
          name: "",
          gender: "",
          hire_date_range: null,
          birth_date_range: null,

        },
        pageInfo: {
          pageIndex: 1,
          pageSize: 10
        }

      }
    };
  },
  mounted: function() {
    //debugger;
    this.getData();
  },
  methods: {
    handleSizeChange(val) {
      //debugger;
      //console.log(`每页 ${val} 条`);
      this.queryCondition.pageInfo.pageSize = val;
      this.getData();
    },
    handleCurrentChange(val) {
      //debugger;
      this.queryCondition.pageInfo.pageIndex = val;
      this.getData();
    },
    getData() {
      let _self = this;
      let url = "/Employee/query";
      //debugger;
      _self.$http
        .post(url, _self.queryCondition)
        .then(function(response) {
          //debugger;
          //console.log(response.data.data);
          _self.pageList = response.data.data;

        })
        .catch(function(error) {
          console.log(error);
        });
    },
    hire_date_pick(maxDate, minDate) {
      //debugger;
      alert(maxDate);
    }
    ,getDetail(currentRow)
    {
      
        this.$router.push({ path: '/index/employeeDetail/' + currentRow.emp_No});
      
    }
  }
};
</script>

<style scoped>
@import '/static/default.css';
</style>


