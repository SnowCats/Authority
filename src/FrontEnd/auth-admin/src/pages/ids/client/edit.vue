<template>
  <div id="system-setting-edit">
    <div class="page-wrapper">
      <v-container grid-list-xl fluid>
        <v-layout row wrap>
          <v-flex sm12>
            <v-widget title="客户端新增">
              <template slot="widget-content">
                <v-container grid-list-xl fluid>
                  <v-form ref="form" v-model="valid" lazy-validation>
                    <v-layout row wrap>
                      <v-tabs v-model="currentTab" dark background-color="#0D47A1" slider-color="#81D4FA">
                        <v-tab href="#detail">详情</v-tab>
                        <v-tab href="#callback">Callback</v-tab>
                        <v-tab href="#signout">Signout</v-tab>
                        <v-tab href="#cors">CORS</v-tab>
                        <v-tab href="#secrets">Secrets</v-tab>
                        <v-tab href="#resource">资源</v-tab>
                        <v-tab href="#advanced">Advanced</v-tab>
                      </v-tabs>
                      <v-tabs-items v-model="currentTab">
                        <v-tab-item value="detail">
                          <v-card flat>
                            <v-card-text>
                              <v-layout row wrap>
                                <v-flex md6 sm12 xs12>
                                  <v-text-field label="客户端Id" v-model="client.clientId"></v-text-field>
                                </v-flex>
                                <v-flex md6 sm12 xs12>
                                  <v-text-field label="客户端名称" v-model="client.clientName"></v-text-field>
                                </v-flex>
                                <v-flex md12 sm12 xs12>
                                  <v-text-field label="描述" v-model="client.description"></v-text-field>
                                </v-flex>
                                <v-flex md12 sm12 xs12>
                                  <v-text-field label="客户端URl" v-model="client.clientUri"></v-text-field>
                                </v-flex>
                                <v-flex md12 sm12 xs12>
                                  <v-text-field label="注销URL" v-model="client.logoUri"></v-text-field>
                                </v-flex>
                                <v-flex md6 sm12 xs12>
                                  <v-checkbox v-model="client.enabled" label="启用"></v-checkbox>
                                </v-flex>
                                <v-flex md6 sm12 xs12>
                                  <v-checkbox v-model="client.requireConsent" label="需要许可"></v-checkbox>
                                </v-flex>
                                <v-flex md6 sm12 xs12>
                                  <v-checkbox v-model="client.AllowRememberConsent" label="需要请求对象"></v-checkbox>
                                </v-flex>
                                <v-flex md6 sm12 xs12>
                                  <v-checkbox v-model="client.allowOfflineAccess" label="允许离线访问"></v-checkbox>
                                </v-flex>
                                <v-flex md12 sm12 xs12>
                                  <v-text-field label="Front-Channel注销URL" v-model="client.frontChannelLogoutUri"></v-text-field>
                                </v-flex>
                                <v-flex md6 sm12 xs12>
                                  <v-checkbox
                                    v-model="client.frontChannelLogoutSessionRequired"
                                    label="需要Front-Channel注销会话"
                                  ></v-checkbox>
                                </v-flex>
                                <v-flex md12 sm12 xs12>
                                  <v-text-field label="Back-Channel注销URL" v-model="client.backChannelLogoutUri"></v-text-field>
                                </v-flex>
                                <v-flex md6 sm12 xs12>
                                  <v-checkbox
                                    v-model="client.backChannelLogoutSessionRequired"
                                    label="需要Back-Channel注销会话"
                                  ></v-checkbox>
                                </v-flex>
                                <v-flex md12 sm12 xs12>
                                  <v-text-field
                                    label="允许的身份令牌签名算法"
                                    v-model="client.allowedIdentityTokenSigningAlgorithms"
                                  ></v-text-field>
                                </v-flex>
                              </v-layout>
                            </v-card-text>
                          </v-card>
                        </v-tab-item>
                        <v-tab-item value="callback">
                          <v-card flat>
                            <v-card-text>Callback</v-card-text>
                          </v-card>
                        </v-tab-item>
                        <v-tab-item value="signout">
                          <v-card flat>
                            <v-card-text>Signout</v-card-text>
                          </v-card>
                        </v-tab-item>
                        <v-tab-item value="cors">
                          <v-card flat>
                            <v-card-text>CORS</v-card-text>
                          </v-card>
                        </v-tab-item>
                        <v-tab-item value="secrets">
                          <v-card>
                            <v-card-text> Secrets </v-card-text>
                          </v-card>
                        </v-tab-item>
                        <v-tab-item value="resource">
                          <v-card>
                            <v-card-text> 资源 </v-card-text>
                          </v-card>
                        </v-tab-item>
                        <v-tab-item value="advanced">
                          <v-card-text> Advanced </v-card-text>
                        </v-tab-item>
                      </v-tabs-items>
                    </v-layout>
                  </v-form>
                </v-container>
              </template>
            </v-widget>
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
      </v-container>
    </div>
  </div>
</template>

<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';
import VWidget from '@/components/VWidget.vue';
import service from '@/services/system/setting';
import Client from '@/types/entities/ids/client';

// 组件注入
@Component({
  components: {
    VWidget,
  },
})

// Vue
export default class Index extends Vue {
  // data
  client: Client = new Client();
  currentTab: any = 0;
  // validation
  valid: boolean = true;
  rules: any = {
    value: [(v: any) => !!v || '必填'],
    text: [(v: any) => !!v || '必填'],
  };
  // list
  select: any = {
    settings: [],
  };

  // mounted
  mounted(): void {}

  // created
  created() {}

  // Methods
  submit(): void {
    console.log('client', this.client);

    // valid
    if ((this.$refs.form as Vue & { validate: () => boolean }).validate()) {
    }
  }
  back(): void {
    // 返回上一级
    this.$router.go(-1);
  }

  onTab(name: string): void {
    console.log(name);
    this.currentTab = name;
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

.v-tabs-items {
  width: 100%;
  padding: 0 15px;
}
</style>