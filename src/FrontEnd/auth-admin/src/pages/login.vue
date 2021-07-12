<template>
  <div class="login-page">
    <div class="container">
      <ul class="content">
        <li class="left-content">
          <p class="title">Login</p>
          <p class="tip">Don't have an account? <a href="javascript:void(0);">Create your account</a>, it takes less than a minute.</p>
          <v-form>
            <v-layout row wrap>
              <v-flex md12 sm12 xs12>
                <v-text-field label="Username" placeholder="Username">
                  <template slot="append">
                    <v-icon>mdi-account</v-icon>
                  </template>
                </v-text-field>
              </v-flex>
              <v-flex md12 sm12 xs12>
                <v-text-field label="Password" placeholder="Password">
                  <template slot="append">
                    <v-icon>mdi-lock</v-icon>
                  </template>
                </v-text-field>
              </v-flex>
              <v-flex md12 sm12 xs12>
                <p class="text-right reset">Forgot password?</p>
              </v-flex>
              <v-flex md12 sm12 xs12>
                <v-btn depressed color="#1768d5" class="btn-login">Login</v-btn>
              </v-flex>
            </v-layout>
          </v-form>
        </li>
        <li class="right-content">
          <p class="title">Welcome</p>
          <v-divider></v-divider>
          <p class="description">Sed do eiusmod temporut labore aet dolore magna aliqua. Your perfact place to buy & sell</p>
        </li>
      </ul>
    </div>
  </div>
</template>

<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';

@Component({})
export default class Login extends Vue {}
</script>

<style lang="scss" scoped>
.login-page {
  background: #dbdce0;
  width: 100vw;
  height: 100vh;

  .container {
    display: flex;
    align-items: center;
    height: 100vh;

    ul.content {
      list-style: none;
      padding: 0 0;
      margin: 0 auto;
      display: flex;
      width: 800px;
      height: 500px;
      background: #ffffff;
      box-shadow: 0 0 50px #999;

      & > li {
        float: left;
        width: 50%;
        padding: 50px 30px;
      }

      & > li.left-content {
        & > .title {
          font-size: 30px !important;
          font-weight: 700;
          color: #444444;
        }

        .tip {
          font-size: 14px;
          color: #7f7f7f;
        }

        .v-form {
          padding: 15px;

          .v-input {
            .v-icon {
              color: #cccccc !important;
            }
          }

          .reset {
            color: #8a8a8a;
            font-size: 14px;
          }

          .btn-login {
            color: #ffffff;
            width: 150px;
            border-radius: 50px;
          }
        }
      }

      & > li.right-content {
        background: linear-gradient(to top right, #bd8ec2, #db8e8e, #dbb08d);

        & > .title {
          color: #ffffff;
          font-size: 40px !important;
          font-weight: 300;
          text-align: center;
          margin-top: 40px;
        }

        & > .v-divider {
          width: 60px;
          border-color: white;
          margin: 20px auto;
        }

        & > .description {
          color: #ffffff;
          text-align: center;
          font-size: 18px;
        }
      }
    }
  }
}
</style>