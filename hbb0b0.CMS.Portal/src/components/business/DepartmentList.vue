<template>
  <div class="testUser">
    <div class="function common-margin">
      <el-row>
        <el-col :span="4">
          <div class="grid-content bg-purple">
            <el-input
              placeholder="请输入部门名称"
              icon="search"
              v-model="input">
            </el-input>
          </div>
        </el-col>
        <el-col :span="20">
          <el-button type="primary">新建部门</el-button>
        </el-col>
      </el-row>

    </div>
    <div id="table">
      <el-table
        :data="pageList.items"
        stripe
        style="width: 100%">
        <el-table-column
          prop="dept_No"
          sortable
          label="部门编号">
        </el-table-column>
        <el-table-column
          prop="dept_Name"
           sortable
          label="部门名称">
        </el-table-column>
        
        <el-table-column
          :context="_self"
          inline-template
          label="操作">
          <span>
            <el-button type="text" size="small">查看</el-button>
            <el-button type="text" size="small">编辑</el-button>
          </span>
        </el-table-column>
      </el-table>
      <div class="block">
      <el-pagination :data="pageList"
      @size-change="handleSizeChange"
      @current-change="handleCurrentChange"
      :current-page="currentPage"
      :page-sizes="[10, 200, 300, 400]"
      :page-size="currentRowPerPage"
      layout="total, sizes, prev, pager, next, jumper"
      :total="pageList.totalCount">
    </el-pagination>
		</div>
    </div>
  </div>
</template>

<script>

  export default {
    data(){
      return {
        input: '',
        pageList:[],
        currentPage:1,
        currentRowPerPage:10
      }

    },
    mounted: function () {
      this.getData();
    },
    methods:{
       handleSizeChange(val) {
        //debugger;
        //console.log(`每页 ${val} 条`);
        this.currentRowPerPage=val;
        this.getData();
      },
      handleCurrentChange(val) {
        //debugger;
        this.currentPage = val;
        this.getData();
      }
      ,getData()
      {
        let _self=this;
        let url="/Department/GetPagedList/"+this.currentPage+"/"+this.currentRowPerPage;
        _self.$http.get(url)
             .then(function (response) {
               //debugger;
                console.log(response.data.data);
                 _self.pageList=response.data.data;
                 
             })
            .catch(function (error) {
              console.log(error);
            });
      }
      
    }


  }
</script>

<style media="screen">
   @import "/static/default.css"
</style>
