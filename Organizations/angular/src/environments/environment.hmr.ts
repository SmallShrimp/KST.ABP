export const environment = {
  production: false,
  hmr: true,
  application: {
    name: 'organizationsApp',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44317',
    clientId: 'organizations_App',
    dummyClientSecret: '1q2w3e*',
    scope: 'organizationsApp',
    showDebugInformation: true,
    oidc: false,
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44317',
    },
  },
  localization: {
    defaultResourceName: 'organizationsApp',
  },
};
