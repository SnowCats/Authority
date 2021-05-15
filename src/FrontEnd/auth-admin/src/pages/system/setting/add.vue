<template>
  <div id="system-setting-add">
    <div class="page-wrapper">
      <v-container grid-list-xl fluid>
        <v-layout row wrap>
          <v-flex sm12>
            <v-widget title="数据字典新增">
              <template slot="widget-content">
                <v-container grid-list-xl fluid>
                  <v-form ref="form" v-model="valid" lazy-validation>
                    <v-layout row wrap>
                      <v-flex md3 sm6 xs12>
                        <v-select
                          label="上级字典值"
                          :clearable="true"
                          v-model="setting"
                          :items="item.value.list"
                          item.text="text"
                          item.value="value"
                        ></v-select>
                      </v-flex>
                      <v-flex md3 sm6 xs12>
                        <v-text-field label="字典值" v-model="setting.value" :rules="rules.value"></v-text-field>
                      </v-flex>
                      <v-flex md3 sm6 xs12>
                        <v-text-field label="字典文本" v-model="setting.text" :rules="rules.text"></v-text-field>
                      </v-flex>
                      <v-flex md12 sm12 xs12>
                        <v-textarea label="备注" v-model="setting.notes"></v-textarea>
                      </v-flex>
                      <v-flex md12 sm12 xs12 class="btns">
                        <v-btn color="green darken-2" class="white--text ma-2" @click="submit()">
                          <v-icon left>mdi-content-save</v-icon>
                          提交
                        </v-btn>
                        <v-btn color="blue-grey lighten-2" class="white--text ma-2" @click="back()">
                          <v-icon left>mdi-bookmark-remove</v-icon>
                          返回
                        </v-btn>
                      </v-flex>
                    </v-layout>
                  </v-form>
                </v-container>
              </template>
            </v-widget>
          </v-flex>
        </v-layout>
      </v-container>
    </div>
  </div>
</template>

<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';
import Setting from '@/types/system/setting';
import VWidget from '../../../components/VWidget.vue';
import service from '../../../services/system/setting';

// 组件注入
@Component({
  components: {
    VWidget,
  },
})

// Vue
export default class Index extends Vue {
  // data
  setting: Setting = new Setting();
  // validation
  valid: boolean = true;
  rules: any = {
    value: [(v:any) => !!v || '必填'],
    text: [(v:any) => !!v || '必填']
  }
  // list
  private item = {
    value: {
      list: [],
    },
  };

  // Methods
  submit(): void {
    console.log('setting', this.setting);

    // valid
    if((this.$refs.form as Vue & { validate: () => boolean }).validate()) {
      service.insert(this.setting).then((res: any) => {
        console.log(res);
        if(!!res.data) {
          this.$root.$alert("success", "新增成功");
          // 返回上级目录
          this.back();
        }
        else {
          this.$root.$alert("warning", "当前字典值已存在，不能重新添加");
        }
      });
    }
  }
  back(): void {
    // 返回上一级
    this.$router.push('.');
  }
}
</script>

<style lang="scss" scoped>
.btns {
  text-align: center;

  .v-btn {
    margin-right: 15px;
  }
}
</style>