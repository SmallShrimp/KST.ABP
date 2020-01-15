export const environment = {
  production: false,
  hmr: false,
  application: {
    name: 'organizationsApp',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44309',
    clientId: 'organizations_ConsoleTestApp',
    dummyClientSecret: '1q2w3e*',
    scope: 'Organizations',
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
    defaultResourceName: 'organizations',
  },
};
