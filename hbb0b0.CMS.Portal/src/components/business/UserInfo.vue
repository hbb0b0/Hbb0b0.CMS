<template>
  <div class="userList">
       <el-button type="primary"  @click="handleClick">获取服务端时间</el-button>
       <p>call from server:{{msg}}</p>
  </div>
</template>

<script>
  import axios from 'axios';
  export default{
    data(){
      return {
          msg:""
      }
    },
    methods: {
       handleClick(evt) {
            let _self= this;
            _self.$http.get('/Department/GetList')
             .then(function (response) {
                 debugger;
                 console.log(response);
                 _self.msg=response.data;
             })
            .catch(function (error) {
               debugger;
              console.log(error);
            });
       }
       
    }
  }

</script>


<style scoped>
.userList
{
   padding-top: 10px;
}
</style>
