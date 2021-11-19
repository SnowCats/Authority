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
                      <v-tabs v-model="currentTab" light>
                        <v-tab href="#detail">详情</v-tab>
                        <v-tab href="#uris">Uris</v-tab>
                        <v-tab href="#secrets">Secrets</v-tab>
                        <v-tab href="#identity_resource">Identity资源</v-tab>
                        <v-tab href="#api_resource">Api资源</v-tab>
                      </v-tabs>
                      <v-tabs-items v-model="currentTab">
                        <v-tab-item value="detail">
                          <v-card flat>
                            <v-card-text>
                              <v-form ref="form" v-model="valid" lazy-validation>
                                <v-layout row wrap>
                                  <v-flex md6 sm12 xs12>
                                    <v-text-field label="客户端Id*" v-model="client.clientId" :rules="rules.client.clientId"></v-text-field>
                                  </v-flex>
                                  <v-flex md6 sm12 xs12>
                                    <v-text-field
                                      label="客户端名称*"
                                      v-model="client.clientName"
                                      :rules="rules.client.clientName"
                                    ></v-text-field>
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
                                    <v-checkbox v-model="client.requireConsent" label="需要许可"></v-checkbox>
                                  </v-flex>
                                </v-layout>
                              </v-form>
                            </v-card-text>
                          </v-card>
                        </v-tab-item>
                        <v-tab-item value="uris">
                          <v-card flat>
                            <v-card-text>
                              <v-layout row wrap>
                                <v-flex md12 sm12 xs12>
                                  <v-text-field label="回调Url" v-model="client.clientRedirectUri.redirectUri"></v-text-field>
                                </v-flex>
                                <v-flex md12 sm12 xs12>
                                  <v-text-field
                                    label="Logout Url"
                                    v-model="client.clientPostLogoutRedirectUri.postLogoutRedirectUri"
                                  ></v-text-field>
                                </v-flex>
                              </v-layout>
                            </v-card-text>
                          </v-card>
                        </v-tab-item>
                        <v-tab-item value="secrets">
                          <v-card flat>
                            <v-card-text>
                              <v-form ref="client_secret_form" v-model="valid" lazy-validation>
                                <v-layout row wrap>
                                  <v-flex md6 sm12 xs12>
                                    <v-select
                                      label="类型"
                                      :items="client_secret_types"
                                      item.text="text"
                                      item.value="value"
                                      v-model="clientSecret.type"
                                    ></v-select>
                                  </v-flex>
                                  <v-flex md6 sm12 xs12>
                                    <v-text-field label="描述" v-model="clientSecret.description"></v-text-field>
                                  </v-flex>
                                  <v-flex md6 sm12 xs12>
                                    <v-text-field label="值" v-model="clientSecret.value" :rules="rules.client_secret.value"></v-text-field>
                                  </v-flex>
                                  <v-flex md6 sm12 xs12>
                                    <v-menu
                                      ref="menu"
                                      v-model="menu"
                                      :close-on-content-click="false"
                                      :return-value.sync="clientSecret.expiration"
                                      transition="scale-transition"
                                      offset-y
                                      min-width="auto"
                                    >
                                      <template v-slot:activator="{ on, attrs }">
                                        <v-text-field
                                          v-model="clientSecret.expiration"
                                          label="到期"
                                          prepend-inner-icon="mdi-calendar"
                                          readonly
                                          v-bind="attrs"
                                          v-on="on"
                                        >
                                        </v-text-field>
                                      </template>
                                      <v-date-picker v-model="clientSecret.expiration" no-title scrollable>
                                        <v-spacer></v-spacer>
                                        <v-btn text color="primary" @click="menu = false"> Cancel </v-btn>
                                        <v-btn text color="primary" @click="$refs.menu.save(clientSecret.expiration)"> OK </v-btn>
                                      </v-date-picker>
                                    </v-menu>
                                  </v-flex>
                                  <v-flex md12 sm12 xs12 class="text-right">
                                    <v-btn small color="#3F51B5" class="white--text ma-2" @click="onCreateClientSecret()">
                                      <v-icon left>mdi-plus</v-icon>
                                      添加一个新的
                                    </v-btn>
                                  </v-flex>
                                  <v-flex md12 sm12 xs12>
                                    <v-data-table
                                      :headers="secret_headers"
                                      :items="client.clientSecrets"
                                      hide-default-footer
                                    ></v-data-table>
                                  </v-flex>
                                </v-layout>
                              </v-form>
                            </v-card-text>
                          </v-card>
                        </v-tab-item>
                        <v-tab-item value="identity_resource">
                          <v-card flat>
                            <v-card-text>
                              <v-chip-group v-model="neighborhoods" column multiple>
                                <v-chip filter outlined> Your user identifier </v-chip>
                                <v-chip filter outlined> User profile </v-chip>
                                <v-chip filter outlined> Your email address </v-chip>
                                <v-chip filter outlined> Your postal address </v-chip>
                                <v-chip filter outlined> Your phone number </v-chip>
                                <v-chip filter outlined> Roles of the user </v-chip>
                              </v-chip-group>
                            </v-card-text>
                          </v-card>
                        </v-tab-item>
                        <v-tab-item value="api_resource">
                          <v-card flat>
                            <v-card-text> Api资源 </v-card-text>
                          </v-card>
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
import Client from '@/types/entities/ids/client';
import Constants from '@/types/utility/constants';
import ClientSecret from '@/types/entities/ids/client-secret';

// 组件注入
@Component({
  components: {
    VWidget,
  },
})

// Vue
export default class Index extends Vue {
  // data
  menu: boolean = false;
  currentTab: any = 0;
  client: Client = new Client();
  client_secret_types: Array<any> = Constants.client_secret_types;
  clientSecret: ClientSecret = new ClientSecret();
  // validation
  valid: boolean = true;
  rules: any = {
    client: {
      clientId: [(v: any) => !!v || '必填'],
      clientName: [(v: any) => !!v || '必填'],
    },
    client_secret: {
      value: [(v: any) => !!v || '必填'],
    },
  };
  // Table
  secret_headers: any[] = [
    {
      text: '类型',
      value: 'type',
      sortable: false,
    },
    {
      text: '值',
      value: 'value',
      sortable: false,
    },
    {
      text: '描述',
      value: 'description',
      sortable: false,
    },
    {
      text: '到期',
      value: 'expiration',
      sortable: false,
    },
  ];
  secret_list: Array<ClientSecret> = [];

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

  // Tab切换
  onTab(name: string): void {
    console.log(name);
    this.currentTab = name;
  }

  // 添加client_secret
  onCreateClientSecret(): void {
    if ((this.$refs.client_secret_form as Vue & { validate: () => boolean }).validate()) {
      this.client.clientSecrets.push(this.clientSecret);
      this.clientSecret = new ClientSecret();
    }
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