export const environment = {
  production: true,
  hmr: false,
  application: {
    name: 'organizationsApp',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44309',
    clientId: 'organizations_App',
    dummyClientSecret: '1q2w3e*',
    scope: 'organizationsApp',
    showDebugInformation: true,
    oidc: false,
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44347',
    },
  },
  localization: {
    defaultResourceName: 'organizationsApp',
  },
};
