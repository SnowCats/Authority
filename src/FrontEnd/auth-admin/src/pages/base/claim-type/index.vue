<template>
  <div class="base-claim-type">
    <div class="page-wrapper">
      <v-container grid-list-xl fluid>
        <v-layout row wrap>
          <v-flex sm12>
            <v-widget title="查询条件">
              <template slot="widget-content">
                <v-container grid-list-xl fluid>
                  <v-layout row wrap>
                    <v-flex md3 sm6 xs12>
                      <v-text-field label="名称"></v-text-field>
                    </v-flex>
                    <v-flex md9 sm12 xs12>
                      <div class="text-right">
                        <v-btn color="green darken-2" class="white--text ma-2" @click="add">
                          <v-icon left>mdi-plus</v-icon>
                          新增
                        </v-btn>
                        <v-btn color="light-blue darken-2" class="white--text ma-2" @click="search">
                          <v-icon left>mdi-magnify</v-icon>
                          查询
                        </v-btn>
                      </div>
                    </v-flex>
                  </v-layout>
                </v-container>
              </template>
            </v-widget>
            <v-data-table
              :headers="headers"
              :items="list"
              :page.sync="pagination.page"
              :items-per-page="pagination.itemsPerPage"
              hide-default-footer
              class="elevation-1"
              @page-count="pagination.count = $event"
            >
              <!-- 序号 -->
              <template v-slot:[`item.id`]="{ item }">
                {{
                  pagination.page *
                    list
                      .map(function (x) {
                        return x.id;
                      })
                      .indexOf(item.id) +
                  1
                }}
              </template>
              <!-- 状态 -->
              <template v-slot:[`item.status`]="{ item }">
                {{ item.status === 1 ? '有效' : '无效' }}
              </template>
              <!-- 操作 -->
              <template v-slot:[`item.actions`]="{ item }">
                <v-icon small class="mr-2" @click="edit(item.id)"> mdi-pencil </v-icon>
                <v-icon small class="mr-2" @click="del(item.id)"> mdi-delete </v-icon>
              </template>
            </v-data-table>
            <div class="text-center pt-2">
              <v-pagination v-model="pagination.page" :length="pagination.count"></v-pagination>
            </div>
          </v-flex>
        </v-layout>
      </v-container>
    </div>
  </div>
</template>

<script lang="ts">
import Pagination from '@/types/common/pagination';
import ClaimType from '@/types/entities/base/claim-type';
import VWidget from '@components/VWidget.vue';
import { Vue, Component, Prop } from 'vue-property-decorator';

@Component({
  components: {
    VWidget,
  },
})
export default class Index extends Vue {
  // data
  claimType: ClaimType = new ClaimType();
  // 查询条件
  pagination: Pagination = new Pagination();
  model: any = {};
  // Table
  headers: any[] = [
    {
      text: '名称',
      value: 'name',
    },
    {
      text: '值类型',
      value: 'valueTypeAsString',
    },
    {
      text: '描述',
      value: 'description',
    },
    {
      text: '必要',
      value: 'required',
    },
    {
      text: '是否静态',
      value: 'isStatic',
    },
    {
      text: '操作',
      value: 'actions'
    }
  ];

  // 分页列表
  list: ClaimType[] = [];

  // mounted
  mounted(): void {}

  // created
  created(): void {}

  // 查询
  search(): void {}

  // 跳转到新增页面
  add(): void {
    console.log('跳转到新增');
    this.$router.push('./claim-type/add');
  }

  // 跳转到编辑页面
  edit(id: string): void {
    console.log('跳转到编辑');
    this.$router.push('./claim-type/edit/' + id);
  }

  // 删除
  del(id: string): void {
    console.log('删除', id);
    this.$root
      .$confirm('确认删除吗？', '删除后数据不可恢复', {
        width: 500,
        okText: '确认',
        okColor: 'primary',
        cancelText: '取消',
        cancelColor: 'default',
      })
      .then((value: boolean) => {
        if (value) {
          // 执行删除操作
        }
      });
  }
}
</script>

<style lang="scss" scoped>
</style>